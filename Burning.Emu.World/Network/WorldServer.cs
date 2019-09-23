using Burning.Common.Network;
using Burning.Emu.World.Game.World;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Burning.Emu.World.Network
{
    class WorldServer : AbstractServer
    {
        public WorldServer(string ipAdress, int port) : base(ipAdress, port)
        {
            //retrive all server
        }

        public override void AcceptCallback(IAsyncResult ar)
        {
            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            //init client
            WorldManager.Instance.worldClients.Add(new WorldClient(handler));
        }
    }
}
