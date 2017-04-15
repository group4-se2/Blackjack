using Common.Lib.Models;
using Common.Lib.Utility;
using Player.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Player
{
    /// <summary>
    /// Custom data received event arguments, holds the data that was received
    /// </summary>
    public class ClientDataReceivedEventArgs : EventArgs
    {
        public CommandObject CmdObject { get; set; }
    }

    // Delegate for hooking up connected notification
    public delegate void ClientConnectedEventHandler(object sender, EventArgs e);

    // Delegate for hooking up receive notification
    public delegate void ClientDataReceivedEventHandler(object sender, ClientDataReceivedEventArgs e);

    public class Client
    {

        private Socket clientSocket;       
        private byte[] byteData = new byte[1024];

        public event ClientConnectedEventHandler OnConnected;
        public event ClientDataReceivedEventHandler OnDataReceived;

        public Client() {}

        public void Connect(string ip, int port)
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                //Connect to the server
                clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect: " + ex.Message);
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);

                byteData = new byte[1024];

                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), byteData);

                // Invoke the OnConneted event if one exists
                if (OnConnected != null)
                {
                    EventArgs e = new EventArgs();
                    OnConnected(this, e);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("OnConnect: " + ex.Message);
            }
        }

        public void Send(CommandObject commandObject)
        {
            try
            {
                byteData = Encoding.ASCII.GetBytes(Serializer.SerializeCommand(commandObject));

                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Send: " + ex.Message);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OnSend: " + ex.Message);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            byte[] data = (byte[])ar.AsyncState;
            try
            {
                clientSocket.EndReceive(ar);
                
                string strData = Encoding.UTF8.GetString(data);
                
               CommandObject commandObject = Deserializer.DeserializeCommand(strData);

               byteData = new byte[1024];

               clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), byteData);

                // Invoke the OnDataReceived event if one exists
                if (OnDataReceived != null)
                {
                    ClientDataReceivedEventArgs e = new ClientDataReceivedEventArgs();
                    e.CmdObject = commandObject;
                    OnDataReceived(this, e);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("OnReceive: " + ex.Message);
            }
        }

    }
}
