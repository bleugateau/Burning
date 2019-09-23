using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PurchasableDialogMessage : NetworkMessage
  {
    public const uint Id = 5739;
    public bool buyOrSell;
    public double purchasableId;
    public uint purchasableInstanceId;
    public bool secondHand;
    public double price;

    public override uint MessageId
    {
      get
      {
        return 5739;
      }
    }

    public PurchasableDialogMessage()
    {
    }

    public PurchasableDialogMessage(
      bool buyOrSell,
      double purchasableId,
      uint purchasableInstanceId,
      bool secondHand,
      double price)
    {
      this.buyOrSell = buyOrSell;
      this.purchasableId = purchasableId;
      this.purchasableInstanceId = purchasableInstanceId;
      this.secondHand = secondHand;
      this.price = price;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.buyOrSell), (byte) 1, this.secondHand);
      writer.WriteByte((byte) num);
      if (this.purchasableId < 0.0 || this.purchasableId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.purchasableId + ") on element purchasableId.");
      writer.WriteDouble(this.purchasableId);
      if (this.purchasableInstanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.purchasableInstanceId + ") on element purchasableInstanceId.");
      writer.WriteInt((int) this.purchasableInstanceId);
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.buyOrSell = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.secondHand = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.purchasableId = reader.ReadDouble();
      if (this.purchasableId < 0.0 || this.purchasableId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.purchasableId + ") on element of PurchasableDialogMessage.purchasableId.");
      this.purchasableInstanceId = (uint) reader.ReadInt();
      if (this.purchasableInstanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.purchasableInstanceId + ") on element of PurchasableDialogMessage.purchasableInstanceId.");
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of PurchasableDialogMessage.price.");
    }
  }
}
