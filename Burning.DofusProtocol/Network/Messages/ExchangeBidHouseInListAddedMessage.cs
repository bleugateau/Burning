using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
    public class ExchangeBidHouseInListAddedMessage : NetworkMessage
    {
        public List<ObjectEffect> effects = new List<ObjectEffect>();
        public List<double> prices = new List<double>();
        public const uint Id = 5949;
        public int itemUID;
        public uint objectGID;
        public uint objectType;

        public override uint MessageId
        {
            get
            {
                return 5949;
            }
        }

        public ExchangeBidHouseInListAddedMessage()
        {
        }

        public ExchangeBidHouseInListAddedMessage(
          int itemUID,
          uint objectGID,
          uint objectType,
          List<ObjectEffect> effects,
          List<double> prices)
        {
            this.itemUID = itemUID;
            this.objectGID = objectGID;
            this.objectType = objectType;
            this.effects = effects;
            this.prices = prices;
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

            writer.WriteShort((short)this.effects.Count);
            for (int index = 0; index < this.effects.Count; ++index)
            {
                writer.WriteShort((short)this.effects[index].TypeId);
                this.effects[index].Serialize(writer);
            }
            writer.WriteShort((short)this.prices.Count);
            for (int index = 0; index < this.prices.Count; ++index)
            {
                if (this.prices[index] < 0.0 || this.prices[index] > 9.00719925474099E+15)
                    throw new Exception("Forbidden value (" + (object)this.prices[index] + ") on element 4 (starting at 1) of prices.");
                writer.WriteVarLong((long)this.prices[index]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            this.itemUID = reader.ReadInt();
            this.objectGID = reader.ReadVarUhShort();
            if (this.objectGID < 0)
            {
                throw new Exception("Forbidden value (" + this.objectGID + ") on element of ExchangeBidHouseInListAddedMessage.objectGID.");
            }
            this.objectType = (uint)reader.ReadInt();
            if (this.objectType < 0)
            {
                throw new Exception("Forbidden value (" + this.objectType + ") on element of ExchangeBidHouseInListAddedMessage.objectType.");
            }

            uint num1 = (uint)reader.ReadUShort();
            for (int index = 0; (long)index < (long)num1; ++index)
            {
                ObjectEffect instance = ProtocolTypeManager.GetInstance<ObjectEffect>((uint)reader.ReadUShort());
                instance.Deserialize(reader);
                this.effects.Add(instance);
            }
            uint num2 = (uint)reader.ReadUShort();
            for (int index = 0; (long)index < (long)num2; ++index)
            {
                double num3 = (double)reader.ReadVarUhLong();
                if (num3 < 0.0 || num3 > 9.00719925474099E+15)
                    throw new Exception("Forbidden value (" + (object)num3 + ") on elements of prices.");
                this.prices.Add(num3);
            }
        }
    }
}
