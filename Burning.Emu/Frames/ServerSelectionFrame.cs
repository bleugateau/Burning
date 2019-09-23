using Burning.Common.Managers.Frame;
using Burning.Common.Utility.Authentication;
using Burning.Emu.Network;
using Burning.DofusProtocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.Frames
{
    class ServerSelectionFrame : Frame
    {
        [PacketId(ServerSelectionMessage.Id)]
        public void ServerSelectionMessageFrame(AuthClient client, ServerSelectionMessage serverSelectionMessage)
        {
            List<uint> ports = new List<uint>();
            ports.Add(6666);

            client.SendPacket(new SelectedServerDataMessage(serverSelectionMessage.serverId, "127.0.0.1", ports, true, AuthenticationUtils.EncodeTicket(client.salt)));
            client.Disconnect();
        }
    }
}
