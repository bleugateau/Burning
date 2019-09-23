using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InventoryWeightMessage : NetworkMessage
  {
    public const uint Id = 3009;
    public uint inventoryWeight;
    public uint shopWeight;
    public uint weightMax;

    public override uint MessageId
    {
      get
      {
        return 3009;
      }
    }

    public InventoryWeightMessage()
    {
    }

    public InventoryWeightMessage(uint inventoryWeight, uint shopWeight, uint weightMax)
    {
      this.inventoryWeight = inventoryWeight;
      this.shopWeight = shopWeight;
      this.weightMax = weightMax;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.inventoryWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.inventoryWeight + ") on element inventoryWeight.");
      writer.WriteVarInt((int) this.inventoryWeight);
      if (this.shopWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.shopWeight + ") on element shopWeight.");
      writer.WriteVarInt((int) this.shopWeight);
      if (this.weightMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.weightMax + ") on element weightMax.");
      writer.WriteVarInt((int) this.weightMax);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.inventoryWeight = reader.ReadVarUhInt();
      if (this.inventoryWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.inventoryWeight + ") on element of InventoryWeightMessage.inventoryWeight.");
      this.shopWeight = reader.ReadVarUhInt();
      if (this.shopWeight < 0U)
        throw new Exception("Forbidden value (" + (object) this.shopWeight + ") on element of InventoryWeightMessage.shopWeight.");
      this.weightMax = reader.ReadVarUhInt();
      if (this.weightMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.weightMax + ") on element of InventoryWeightMessage.weightMax.");
    }
  }
}
