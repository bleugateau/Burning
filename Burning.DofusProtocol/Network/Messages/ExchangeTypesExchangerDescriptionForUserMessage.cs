using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
    public class ExchangeTypesExchangerDescriptionForUserMessage : NetworkMessage
    {
        public List<uint> typeDescription = new List<uint>();
        public const uint Id = 5765;
        public uint objectType;

        public override uint MessageId
        {
            get
            {
                return 5765;
            }
        }

        public ExchangeTypesExchangerDescriptionForUserMessage()
        {
        }

        public ExchangeTypesExchangerDescriptionForUserMessage(uint objectType, List<uint> typeDescription)
        {
            this.objectType = objectType;
            this.typeDescription = typeDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
            if (this.objectType < 0)
            {
                throw new Exception("Forbidden value (" + this.objectType + ") on element objectType.");
            }
            writer.WriteInt((int)this.objectType);
            writer.WriteShort((short)this.typeDescription.Count);
            for (int index = 0; index < this.typeDescription.Count; ++index)
            {
                if (this.typeDescription[index] < 0U)
                    throw new Exception("Forbidden value (" + (object)this.typeDescription[index] + ") on element 1 (starting at 1) of typeDescription.");
                writer.WriteVarInt((int)this.typeDescription[index]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            this.objectType = (uint)reader.ReadInt();
            if (this.objectType < 0)
            {
                throw new Exception("Forbidden value (" + this.objectType + ") on element of ExchangeTypesExchangerDescriptionForUserMessage.objectType.");
            }
            uint num1 = (uint)reader.ReadUShort();
            for (int index = 0; (long)index < (long)num1; ++index)
            {
                uint num2 = reader.ReadVarUhInt();
                if (num2 < 0U)
                    throw new Exception("Forbidden value (" + (object)num2 + ") on elements of typeDescription.");
                this.typeDescription.Add(num2);
            }
        }
    }
}
