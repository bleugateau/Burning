using Burning.Common.Managers.Frame;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Frames
{
    public class AdminFrames : Frame
    {
        //AdminQuietCommandMessage
        [PacketId(AdminQuietCommandMessage.Id)]
        public void AdminQuietCommandMessageFrame(WorldClient client, AdminQuietCommandMessage adminQuietCommandMessage)
        {
            Console.WriteLine(adminQuietCommandMessage.content);
            string[] content = adminQuietCommandMessage.content.Split(" ");

            int.TryParse(content[1], out int mapId);

            if (mapId != 0 && mapId != null)
            {
                client.ActiveCharacter.MapId = mapId;

                client.SendPacket(new GameContextDestroyMessage());
                client.SendPacket(new GameContextCreateMessage(1));

                client.SendPacket(new CurrentMapMessage(client.ActiveCharacter.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));
            }
        }
    }
}
