using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseSellingUpdateMessage : NetworkMessage
  {
    public const uint Id = 6727;
    public uint houseId;
    public uint instanceId;
    public bool secondHand;
    public double realPrice;
    public string buyerName;

    public override uint MessageId
    {
      get
      {
        return 6727;
      }
    }

    public HouseSellingUpdateMessage()
    {
    }

    public HouseSellingUpdateMessage(
      uint houseId,
      uint instanceId,
      bool secondHand,
      double realPrice,
      string buyerName)
    {
      this.houseId = houseId;
      this.instanceId = instanceId;
      this.secondHand = secondHand;
      this.realPrice = realPrice;
      this.buyerName = buyerName;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      writer.WriteBoolean(this.secondHand);
      if (this.realPrice < 0.0 || this.realPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.realPrice + ") on element realPrice.");
      writer.WriteVarLong((long) this.realPrice);
      writer.WriteUTF(this.buyerName);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseSellingUpdateMessage.houseId.");
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseSellingUpdateMessage.instanceId.");
      this.secondHand = reader.ReadBoolean();
      this.realPrice = (double) reader.ReadVarUhLong();
      if (this.realPrice < 0.0 || this.realPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.realPrice + ") on element of HouseSellingUpdateMessage.realPrice.");
      this.buyerName = reader.ReadUTF();
    }
  }
}
