using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
    public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
    {
        public const uint Id = 5950;
        public int itemUID;
        public uint objectGID;
        public uint objectType;

        public override uint MessageId
        {
            get
            {
                return 5950;
            }
        }

        public ExchangeBidHouseInListRemovedMessage()
        {
        }

        public ExchangeBidHouseInListRemovedMessage(int itemUID, uint objectGID, uint objectType)
        {
            this.itemUID = itemUID;
            this.objectGID = objectGID;
            this.objectType = objectType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(this.itemUID);
            if (this.objectGID < 0)
            {
                throw new Exception("Forbidden value (" + this.objectGID + ") on element objectGID.");
            }
            writer.WriteVarShort((short)this.objectGID);
            if (this.objectType < 0)
            {
                throw new Exception("Forbidden value (" + this.objectType + ") on element objectType.");
            }
            writer.WriteInt((int)this.objectType);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.itemUID = reader.ReadInt();
            this.objectGID = reader.ReadVarUhShort();
            if (this.objectGID < 0)
            {
                throw new Exception("Forbidden value (" + this.objectGID + ") on element of ExchangeBidHouseInListRemovedMessage.objectGID.");
            }

            this.objectType = (uint)reader.ReadInt();
            if (this.objectType < 0)
            {
                throw new Exception("Forbidden value (" + this.objectType + ") on element of ExchangeBidHouseInListRemovedMessage.objectType.");
            }
        }
    }
}
