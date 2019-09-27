using Burning.Common.Managers.Frame;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Network;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.Common.Utility.EntityLook;
using Burning.Common.Repository;
using Burning.Emu.World.Repository;
using Burning.Emu.World.Game.World;

namespace Burning.Emu.World.Frames
{
    public class InventoryFrames
    {
        [PacketId(ObjectSetPositionMessage.Id)]
        public void ObjectSetPositionMessageFrame(WorldClient client, ObjectSetPositionMessage objectSetPositionMessage)
        {
            var character = client.ActiveCharacter;
            var item = InventoryRepository.Instance.GetItemFromUID(character.Inventory, (int)objectSetPositionMessage.objectUID);

            if (item == null)
                return;

            switch ((CharacterInventoryPositionEnum)objectSetPositionMessage.position)
            {
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_COSTUME:
                    if (item.typeId != 199)
                        return;

                    InventoryRepository.Instance.MoveItemToPosition(client, (int)objectSetPositionMessage.objectUID, (int)objectSetPositionMessage.position);
                    break;
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_HAT:
                    if (item.typeId == 16 || item.typeId == 177)
                    {
                        InventoryRepository.Instance.MoveItemToPosition(client, (int)objectSetPositionMessage.objectUID, (int)objectSetPositionMessage.position, item.typeId == 177 ? true : false);
                    }
                    break;
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_CAPE:
                    if (item.typeId == 81 || item.typeId == 17) //cape et sac
                    {
                        InventoryRepository.Instance.MoveItemToPosition(client, (int)objectSetPositionMessage.objectUID, (int)objectSetPositionMessage.position);
                    }
                    break;
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED:
                    InventoryRepository.Instance.UnequipItem(client, client.ActiveCharacter.Inventory, (int)objectSetPositionMessage.objectUID);
                    break;
            }

            //update du skin
            this.SendInventoryWeight(client);
        }

        [PacketId(WrapperObjectDissociateRequestMessage.Id)]
        public void WrapperObjectDissociateRequestMessageFrame(WorldClient client, WrapperObjectDissociateRequestMessage wrapperObjectDissociateRequestMessage)
        {
            if (client.ActiveCharacter == null)
                return;

            InventoryRepository.Instance.DissociateApparat(client, (int)wrapperObjectDissociateRequestMessage.hostUID);

            //update du skin
            this.SendInventoryWeight(client);
        }

        private void SendInventoryWeight(WorldClient client)
        {
            client.SendPacket(new InventoryWeightMessage(0, 0, 1000));
            client.SendPacket(new GameContextRefreshEntityLookMessage((double)client.ActiveCharacter.Id, client.ActiveCharacter.Look));

            WorldManager.Instance.UpdateRolePlayActor(client.ActiveCharacter);
        }
    }
}
