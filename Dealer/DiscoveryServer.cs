using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace Dealer
{
    class DiscoveryServer
    {
        private const string MULTICAST_GROUP_ADDRESS = "239.0.0.222";
        private const int MULTICAST_PORT = 2222;

        private Timer timer;
        private UdpClient udpClient;
        private IPEndPoint remoteEndPoint;
        private string gameServerName;
        private string gameServerIp;
        private int gameServerPort;

        public DiscoveryServer(string gameServerName, int gameServerPort)
        {
            // Add location information to game server variables
            this.gameServerIp = getGameServerIpAddress();
            this.gameServerPort = gameServerPort;
            this.gameServerName = gameServerName;

            this.udpClient = new UdpClient();

            // Join multicast group 
            IPAddress multicastaddress = IPAddress.Parse(MULTICAST_GROUP_ADDRESS);
            this.udpClient.JoinMulticastGroup(multicastaddress);

            // Create an endpoint for multicast server 
            this.remoteEndPoint = new IPEndPoint(multicastaddress, MULTICAST_PORT);

            // Create a timer with a one second interval.
            this.timer = new System.Timers.Timer(1000);

            // Hook up the Elapsed event for the timer. 
            this.timer.Elapsed += OnTimedEvent;
            this.timer.AutoReset = true;
        }

        public void Start()
        {
            this.timer.Enabled = true;
        }

        public void Stop()
        {
            this.timer.Enabled = false;
        }

        private String getGameServerIpAddress()
        {
            // Setup a UDP socket
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                // Try to connect to arbitrary ip and port, doesn't matter if we connect or not
                socket.Connect("10.0.2.4", 65530);

                // Get ip address from socket.LocalEndPoint
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Buffer to hold outgoing data
            Byte[] buffer = null;

            // Set buffer equal to the game servers name, ip address and port
            buffer = Encoding.Unicode.GetBytes(gameServerName + " " + this.gameServerIp + ":" + this.gameServerPort);

            // Multicast packet across lan
            udpClient.Send(buffer, buffer.Length, this.remoteEndPoint);
        }
    }
}

