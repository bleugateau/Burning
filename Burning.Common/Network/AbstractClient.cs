using Burning.Common.Managers.Frame;
using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Burning.Common.Network
{
    public abstract class AbstractClient
    {
        public Socket Socket { get; set; }
        public byte[] Buffer { get; set; }
        public AbstractClient(Socket socket)
        {
            this.Socket = socket;
            this.Buffer = new byte[8192];

            if (this.IsAlive())
                this.Socket.BeginReceive(this.Buffer, 0, this.Buffer.Length, 0, new AsyncCallback(ReadCallback), this.Socket);
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            client.EndConnect(ar);

            if (this.IsAlive())
                this.Socket.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(ReadCallback), client);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;

            if (!this.IsAlive())
                return;

            //decode packet
            BigEndianReader reader = new BigEndianReader(this.Buffer);

            //check in my frame
            FrameManager.Dispatch(this, this.Buffer);

            if (this.IsAlive())
                this.Socket.BeginReceive(this.Buffer, 0, this.Buffer.Length, 0, new AsyncCallback(ReadCallback), this.Socket);
        }


        private void SendCallBack(IAsyncResult ar)
        {
            if (!this.IsAlive())
                return;

            Socket handler = (Socket)ar.AsyncState;
            int bytesSent = handler.EndSend(ar);
        }

        public void SendPacket(NetworkMessage message)
        {
            if (!this.IsAlive())
                return;

            BigEndianWriter writer = new BigEndianWriter();
            message.Pack(writer);

            Console.WriteLine("Send: {0}.", message.GetType().Name);

            if (this.IsAlive())
                this.Socket.Send(writer.Data);
        }

        public bool IsAlive()
        {
            if ((this.Socket != null && this.Socket.Connected))
            {
                try
                {
                    if (this.Socket.Poll(0, SelectMode.SelectRead))
                    {
                        if (this.Socket.Receive(new byte[1], SocketFlags.Peek) == 0)
                        {
                            this.Disconnect();
                            return false;
                        }
                            
                    }
                    return true;
                }
                catch (SocketException ex)
                {
                    this.Disconnect();
                    return false;
                }
            }
            else
            {
                this.Disconnect();
                return false;
            }
        }


        public abstract void Disconnect();
    }
}
