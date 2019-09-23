using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
  {
    public new const uint Id = 6236;
    public uint storageMaxSlot;

    public override uint MessageId
    {
      get
      {
        return 6236;
      }
    }

    public ExchangeStartedWithStorageMessage()
    {
    }

    public ExchangeStartedWithStorageMessage(int exchangeType, uint storageMaxSlot)
      : base(exchangeType)
    {
      this.storageMaxSlot = storageMaxSlot;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.storageMaxSlot < 0U)
        throw new Exception("Forbidden value (" + (object) this.storageMaxSlot + ") on element storageMaxSlot.");
      writer.WriteVarInt((int) this.storageMaxSlot);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.storageMaxSlot = reader.ReadVarUhInt();
      if (this.storageMaxSlot < 0U)
        throw new Exception("Forbidden value (" + (object) this.storageMaxSlot + ") on element of ExchangeStartedWithStorageMessage.storageMaxSlot.");
    }
  }
}
