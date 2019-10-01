using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
    {
        public List<BidExchangerObjectInfo> itemTypeDescriptions = new List<BidExchangerObjectInfo>();
        public const uint Id = 5752;
        public uint objectType;

        public override uint MessageId
        {
            get
            {
                return 5752;
            }
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage(uint objectType,
          List<BidExchangerObjectInfo> itemTypeDescriptions)
        {
            this.objectType = objectType;
            this.itemTypeDescriptions = itemTypeDescriptions;
        }

        public override void Serialize(IDataWriter writer)
        {
            if (this.objectType < 0)
            {
                throw new Exception("Forbidden value (" + this.objectType + ") on element objectType.");
            }
            writer.WriteInt((int)this.objectType);
            writer.WriteShort((short)this.itemTypeDescriptions.Count);
            for (int index = 0; index < this.itemTypeDescriptions.Count; ++index)
                this.itemTypeDescriptions[index].Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.objectType = (uint)reader.ReadInt();
            if (this.objectType < 0)
            {
                throw new Exception("Forbidden value (" + this.objectType + ") on element of ExchangeTypesItemsExchangerDescriptionForUserMessage.objectType.");
            }
            uint num = (uint)reader.ReadUShort();
            for (int index = 0; (long)index < (long)num; ++index)
            {
                BidExchangerObjectInfo exchangerObjectInfo = new BidExchangerObjectInfo();
                exchangerObjectInfo.Deserialize(reader);
                this.itemTypeDescriptions.Add(exchangerObjectInfo);
            }
        }
    }
}
