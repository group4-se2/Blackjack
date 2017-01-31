using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Player
{
    /// <summary>
    /// Custom data received event arguments, holds the data that was received
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        public string Data { get; set; }
    }

    // Delegate for hooking up receive notification
    public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);

    /// <summary>
    /// This class will wait for data from the discovery server
    /// </summary>
    class DiscoveryClient
    {
        private const string MULTICAST_GROUP_ADDRESS = "239.0.0.222";
        private const int MULTICAST_PORT = 2222;

        UdpClient client;
        private IPEndPoint localEp;

        // An event that clients can use to be notified of data reception from the discovery server
        public event DataReceivedEventHandler OnDataReceived;

        /// <summary>
        /// Constructor for ServerDiscover class
        /// </summary>
        public DiscoveryClient()
        {
            // Setup Udp client
            client = new UdpClient();

            client.ExclusiveAddressUse = false;
            localEp = new IPEndPoint(IPAddress.Any, MULTICAST_PORT);

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;

            // Bind client to local endpoint
            client.Client.Bind(localEp);

            // Join multicast group
            IPAddress multicastaddress = IPAddress.Parse(MULTICAST_GROUP_ADDRESS);
            client.JoinMulticastGroup(multicastaddress);

        }

        /// <summary>
        /// Starts client listening for data from the server
        /// </summary>
        public void Start()
        {
            // Start async receive on client
            client.BeginReceive(new AsyncCallback(DataReceived), client);
        }

        /// <summary>
        /// The async callback for client.BeginReceive
        /// Get called when data is received from the server
        /// </summary>
        /// <param name="ar"></param>
        private void DataReceived(IAsyncResult ar)
        {
            UdpClient client = (UdpClient)ar.AsyncState;

            // Read data from the remote server
            byte[] data = client.EndReceive(ar, ref localEp);
            string strData = Encoding.Unicode.GetString(data);

            // Invoke the OnDataReceived event if one exists
            if (OnDataReceived != null)
            {
                DataReceivedEventArgs e = new DataReceivedEventArgs();
                e.Data = strData;
                OnDataReceived(this, e);
            }
        }
    }
}

