using Burning.Common.Managers.Frame;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Frames
{
    public class InventoryFrames
    {
        [PacketId(ObjectSetPositionMessage.Id)]
        public void ObjectSetPositionMessageFrame(WorldClient client, ObjectSetPositionMessage objectSetPositionMessage)
        {
            switch((CharacterInventoryPositionEnum)objectSetPositionMessage.position)
            {
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED:
                    client.SendPacket(new ObjectMovementMessage(objectSetPositionMessage.objectUID, objectSetPositionMessage.position));
                    break;
            }
        }
    }
}
