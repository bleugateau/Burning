using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PaddockSellBuyDialogMessage : NetworkMessage
  {
    public const uint Id = 6018;
    public bool bsell;
    public uint ownerId;
    public double price;

    public override uint MessageId
    {
      get
      {
        return 6018;
      }
    }

    public PaddockSellBuyDialogMessage()
    {
    }

    public PaddockSellBuyDialogMessage(bool bsell, uint ownerId, double price)
    {
      this.bsell = bsell;
      this.ownerId = ownerId;
      this.price = price;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.bsell);
      if (this.ownerId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ownerId + ") on element ownerId.");
      writer.WriteVarInt((int) this.ownerId);
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.bsell = reader.ReadBoolean();
      this.ownerId = reader.ReadVarUhInt();
      if (this.ownerId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ownerId + ") on element of PaddockSellBuyDialogMessage.ownerId.");
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of PaddockSellBuyDialogMessage.price.");
    }
  }
}
