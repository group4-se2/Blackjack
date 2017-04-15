using Common.Lib.Interfaces;
using Common.Lib.Models;
using Common.Lib.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Dealer
{
    /// <summary>
    /// Custom data received event arguments, holds the data that was received
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        public CommandObject CmdObject { get; set; }
    }

    // Delegate for hooking up receive notification
    public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);

    public class Server
    {
        //The ClientConnection class holds the required information about every
        //client connected to the server
        class ClientConnection
        {
            //private byte[] _data = new byte[1024];

            public Socket Socket { get; set; }
            public string Name { get; set; }
            public byte[] Data { get; set; }
        }

        public event DataReceivedEventHandler OnDataReceived;

        // BACKLOG is the number of incoming connections that can be queued for acceptance.
        private const int MAX_CLIENT_COUNT = 4;
        private const int BACKLOG = 6;
        private IPAddress SERVER_ADDRESS = IPAddress.Any;
        private const int SERVER_PORT = 7777;

        //The collection of all clients actively logged into the server
        List<ClientConnection> activeConnections = new List<ClientConnection>();

        //The main socket on which the server listens for clients
        Socket serverSocket;

        /// <summary>
        /// Constructor for the Server object
        /// </summary>
        public Server()
        {
            try
            {
                // The server socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Create the server endpoint
                IPEndPoint ipEndPoint = new IPEndPoint(SERVER_ADDRESS, SERVER_PORT);

                // Bind and listen for incoming connections
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(BACKLOG);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int GetPort()
        {
            return SERVER_PORT;
        }

        public void Start()
        {
            // Start accepting the incoming connections
            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
        }

        /// <summary>
        /// Send a command object to an individual client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="commandObject"></param>
        public void Send(string name, CommandObject commandObject)
        {
            byte[] data = Encoding.ASCII.GetBytes(Serializer.SerializeCommand(commandObject));

            // Find the client connection in activeConnections and return the object
            ClientConnection client = activeConnections.Find(x => x.Name == name);

            client.Socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSend), client);
        }
        
        /// <summary>
        /// Send a command object to all active clients
        /// </summary>
        /// <param name="commandObject"></param>
        public void SendAll(CommandObject commandObject)
        {
            String s = Serializer.SerializeCommand(commandObject);
            byte[] data = Encoding.ASCII.GetBytes(Serializer.SerializeCommand(commandObject));

            // Iterate all clients in activeConnections and send to each
            foreach(ClientConnection client in activeConnections)
            {
                client.Socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSend), client);
            }
        }

        /// <summary>
        /// Async callback that accepts a client connection and starts data reception
        /// </summary>
        /// <param name="ar"></param>
        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);

                // Start listening for more connections
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

                // Create ClientConnection object
                ClientConnection cc = new ClientConnection();
                cc.Socket = clientSocket;
                cc.Data = new byte[1024];

                // Start receiving commands
                clientSocket.BeginReceive(cc.Data, 0, cc.Data.Length, SocketFlags.None, new AsyncCallback(OnReceive), cc);

                Console.WriteLine("Client connected");

            }
            catch (Exception ex)
            {
                Console.WriteLine("OnAccept: " + ex.Message);
            }
        }

        /// <summary>
        /// Async callback the receives data from the client
        /// </summary>
        /// <param name="ar"></param>
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                ClientConnection currentClient = (ClientConnection)ar.AsyncState;
                currentClient.Socket.EndReceive(ar);

                //CommandObject commandObject = JsonConvert.DeserializeObject<CommandObject>(Encoding.UTF8.GetString(currentClient.Data));
                CommandObject commandObject = Deserializer.DeserializeCommand(Encoding.UTF8.GetString(currentClient.Data));

                byte[] data;

                switch (commandObject.Command)
                {
                    // Peek at commandObject to see if it is a join
                    case Command.Join:

                        IPlayer player = commandObject.Players[0];

                        currentClient.Name = player.Name;

                        if (activeConnections.Count < MAX_CLIENT_COUNT)
                        {
                            if (activeConnections.Find(x => x.Name == currentClient.Name) == null)
                            {
                                // Add connection to activeConnections
                                activeConnections.Add(currentClient);

                                // Change commandObject to accepted
                                commandObject.Command = Command.Join;
                                commandObject.Response = Response.Accepted;
                                commandObject.Message = "Welcome";
                            }
                            else
                            {
                                // Player name is already in use, so reject join request
                                commandObject.Command = Command.Join;
                                commandObject.Response = Response.Rejected;
                                commandObject.Message = "Name already in use.";
                            }
                        }
                        else
                        {
                            // Already maximum number of players, so reject join request
                            commandObject.Command = Command.Join;
                            commandObject.Response = Response.Rejected;
                            commandObject.Message = "Too many players.";
                        }
                        data = Encoding.ASCII.GetBytes(Serializer.SerializeCommand(commandObject));

                        // Send acknowledgement back to client
                        currentClient.Socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSend), currentClient);

                        break;

                    // Peek at commandObject to see if it is a exit
                    case Command.Exit:

                        // Find client in active connections and remove it from list
                        int nIndex = 0;
                        foreach (ClientConnection client in activeConnections)
                        {
                            if (client.Socket == currentClient.Socket)
                            {
                                activeConnections.RemoveAt(nIndex);
                                break;
                            }
                            ++nIndex;
                        }

                        // Close the client socket
                        currentClient.Socket.Close();

                        break;
                }

                //If the user is exiting then we don't need to listen anymore
                if (commandObject.Command != Command.Exit)
                {
                    currentClient.Data = new byte[1024];
                    //Start listening for messages sent by the client
                    currentClient.Socket.BeginReceive(currentClient.Data, 0, currentClient.Data.Length, SocketFlags.None, new AsyncCallback(OnReceive), currentClient);
                }

                // Invoke the OnDataReceived event if one exists
                if (OnDataReceived != null && commandObject.Response != Response.Rejected)
                {
                    DataReceivedEventArgs e = new DataReceivedEventArgs();
                    e.CmdObject = commandObject;
                    OnDataReceived(this, e);
                }

            }
            catch (SocketException ex)
            {
                ClientConnection currentClient = (ClientConnection)ar.AsyncState;
                if (ex.ErrorCode == 10054)
                {
                    // Find client in active connections and remove it from list
                    int nIndex = 0;
                    foreach (ClientConnection client in activeConnections)
                    {
                        if (client.Socket == currentClient.Socket)
                        {
                            activeConnections.RemoveAt(nIndex);
                            break;
                        }
                        ++nIndex;
                    }

                    // Close the client socket
                    currentClient.Socket.Close();
                    CommandObject commandObject = new CommandObject();
                    commandObject.Command = Command.Exit;
                    commandObject.Players = new List<IPlayer>();
                    commandObject.Players.Add(new Player() { Name = currentClient.Name });

                    // Invoke the OnDataReceived event if one exists
                    if (OnDataReceived != null)
                    {
                        DataReceivedEventArgs e = new DataReceivedEventArgs();
                        e.CmdObject = commandObject;
                        OnDataReceived(this, e);
                    }
                    Console.WriteLine("Client (" + currentClient.Name + ") has disconnected.");
                }
            }
        }

        /// <summary>
        /// Async callback that completes a send operation
        /// </summary>
        /// <param name="ar"></param>
        public void OnSend(IAsyncResult ar)
        {
            try
            {
                ClientConnection clientConnection = (ClientConnection)ar.AsyncState;
                clientConnection.Socket.EndSend(ar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OnSend: " + ex.Message);
            }
        }
    }
}
