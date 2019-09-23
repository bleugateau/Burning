using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseBuyResultMessage : NetworkMessage
  {
    public const uint Id = 5735;
    public uint houseId;
    public uint instanceId;
    public bool secondHand;
    public bool bought;
    public double realPrice;

    public override uint MessageId
    {
      get
      {
        return 5735;
      }
    }

    public HouseBuyResultMessage()
    {
    }

    public HouseBuyResultMessage(
      uint houseId,
      uint instanceId,
      bool secondHand,
      bool bought,
      double realPrice)
    {
      this.houseId = houseId;
      this.instanceId = instanceId;
      this.secondHand = secondHand;
      this.bought = bought;
      this.realPrice = realPrice;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.secondHand), (byte) 1, this.bought);
      writer.WriteByte((byte) num);
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      if (this.realPrice < 0.0 || this.realPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.realPrice + ") on element realPrice.");
      writer.WriteVarLong((long) this.realPrice);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.secondHand = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.bought = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseBuyResultMessage.houseId.");
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseBuyResultMessage.instanceId.");
      this.realPrice = (double) reader.ReadVarUhLong();
      if (this.realPrice < 0.0 || this.realPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.realPrice + ") on element of HouseBuyResultMessage.realPrice.");
    }
  }
}
