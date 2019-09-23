using Burning.Common.Entity;
using Burning.Common.Managers.Frame;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.DofusProtocol.Network.Types;

namespace Burning.Emu.World.Frames
{
    class QuestFrames : Frame
    {
        //QuestListRequestMessage
        [PacketId(QuestListRequestMessage.Id)]
        public void QuestListRequestMessageFrame(WorldClient client, QuestListRequestMessage questListRequestMessage)
        {
            client.SendPacket(new QuestListMessage(new List<uint>(), new List<uint>(), new List<QuestActiveInformations>(), new List<uint>())); //quest list
        }
    }
}
