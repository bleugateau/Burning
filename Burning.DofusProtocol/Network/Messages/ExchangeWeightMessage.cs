using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeWeightMessage : NetworkMessage
  {
    public const uint Id = 5793;
    public uint currentWeight;
    public uint maxWeight;

    public override uint MessageId
    {
      get
      {
        return 5793;
      }
    }

    public ExchangeWeightMessage()
    {
    }

    public ExchangeWeightMessage(uint currentWeight, uint maxWeight)
    {
      this.currentWeight = currentWeight;
      this.maxWeight = maxWeight;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.currentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.currentWeight + ") on element currentWeight.");
      writer.WriteVarInt((int) this.currentWeight);
      if (this.maxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxWeight + ") on element maxWeight.");
      writer.WriteVarInt((int) this.maxWeight);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.currentWeight = reader.ReadVarUhInt();
      if (this.currentWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.currentWeight + ") on element of ExchangeWeightMessage.currentWeight.");
      this.maxWeight = reader.ReadVarUhInt();
      if (this.maxWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxWeight + ") on element of ExchangeWeightMessage.maxWeight.");
    }
  }
}
