using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Burning.Common.Network
{
    public abstract class AbstractServer
    {
        public string IpAdress { get; set; }
        public int Port { get; set; }
        public byte[] Buffer { get; set; }

        public List<AbstractClient> clients = new List<AbstractClient>();

        public AbstractServer(string ipAdress, int port)
        {
            this.IpAdress = ipAdress;
            this.Port = port;
            this.Buffer = new byte[8192];
        }

        public void Start()
        {
            IPAddress ipAddress = IPAddress.Parse(this.IpAdress);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, this.Port);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                Console.WriteLine("Server started on {0}:{1}.", this.IpAdress, this.Port);

                while (true)
                {
                    // Start an asynchronous socket to listen for connections.  
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    Thread.Sleep(200);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }

        public virtual void AcceptCallback(IAsyncResult ar) { }
    }
}
