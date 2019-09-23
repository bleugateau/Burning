using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangePodsModifiedMessage : ExchangeObjectMessage
  {
    public new const uint Id = 6670;
    public uint currentWeight;
    public uint maxWeight;

    public override uint MessageId
    {
      get
      {
        return 6670;
      }
    }

    public ExchangePodsModifiedMessage()
    {
    }

    public ExchangePodsModifiedMessage(bool remote, uint currentWeight, uint maxWeight)
      : base(remote)
    {
      this.currentWeight = currentWeight;
      this.maxWeight = maxWeight;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.currentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.currentWeight + ") on element currentWeight.");
      writer.WriteVarInt((int) this.currentWeight);
      if (this.maxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxWeight + ") on element maxWeight.");
      writer.WriteVarInt((int) this.maxWeight);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.currentWeight = reader.ReadVarUhInt();
      if (this.currentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.currentWeight + ") on element of ExchangePodsModifiedMessage.currentWeight.");
      this.maxWeight = reader.ReadVarUhInt();
      if (this.maxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxWeight + ") on element of ExchangePodsModifiedMessage.maxWeight.");
    }
  }
}
