using Burning.Common.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Burning.Emu.Network
{
    class AuthServer : AbstractServer
    {
        public AuthServer(string ipAdress, int port) : base (ipAdress, port)
        {
            //retrive all server

        }

        public override void AcceptCallback(IAsyncResult ar)
        {
            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            //init client
            this.clients.Add(new AuthClient(handler));
        }
    }
}
