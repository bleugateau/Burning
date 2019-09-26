using Burning.Common.Entity;
using Burning.Common.Network;
using Burning.Emu.World.Game.World;
using Burning.DofusProtocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Burning.Emu.World.Entity;

namespace Burning.Emu.World.Network
{
    public class WorldClient : AbstractClient
    {
        public Account Account { get; set; }
        public Character ActiveCharacter { get; set; }

        public WorldClient(Socket socket) : base(socket)
        {
            Console.WriteLine("Switched to world server.");

            this.SendPacket(new ProtocolRequired(1937, 1937));
            this.SendPacket(new HelloGameMessage());
        }

        public override void Disconnect()
        {
            this.Socket.Close();
            this.Socket.Dispose();

            //send remove element to other client in same map
            if (this.ActiveCharacter != null)
            {
                foreach (var otherClient in WorldManager.Instance.GetNearestClientsFromCharacter(this.ActiveCharacter))
                {
                    otherClient.SendPacket(new GameContextRemoveElementMessage(this.ActiveCharacter.Id));
                }
            }
            

            WorldManager.Instance.worldClients.Remove(this);
        }
    }
}
