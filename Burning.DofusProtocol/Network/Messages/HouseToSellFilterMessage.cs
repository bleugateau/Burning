using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseToSellFilterMessage : NetworkMessage
  {
    public const uint Id = 6137;
    public int areaId;
    public uint atLeastNbRoom;
    public uint atLeastNbChest;
    public uint skillRequested;
    public double maxPrice;
    public uint orderBy;

    public override uint MessageId
    {
      get
      {
        return 6137;
      }
    }

    public HouseToSellFilterMessage()
    {
    }

    public HouseToSellFilterMessage(
      int areaId,
      uint atLeastNbRoom,
      uint atLeastNbChest,
      uint skillRequested,
      double maxPrice,
      uint orderBy)
    {
      this.areaId = areaId;
      this.atLeastNbRoom = atLeastNbRoom;
      this.atLeastNbChest = atLeastNbChest;
      this.skillRequested = skillRequested;
      this.maxPrice = maxPrice;
      this.orderBy = orderBy;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.areaId);
      if (this.atLeastNbRoom < 0U)
        throw new Exception("Forbidden value (" + (object) this.atLeastNbRoom + ") on element atLeastNbRoom.");
      writer.WriteByte((byte) this.atLeastNbRoom);
      if (this.atLeastNbChest < 0U)
        throw new Exception("Forbidden value (" + (object) this.atLeastNbChest + ") on element atLeastNbChest.");
      writer.WriteByte((byte) this.atLeastNbChest);
      if (this.skillRequested < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillRequested + ") on element skillRequested.");
      writer.WriteVarShort((short) this.skillRequested);
      if (this.maxPrice < 0.0 || this.maxPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.maxPrice + ") on element maxPrice.");
      writer.WriteVarLong((long) this.maxPrice);
      writer.WriteByte((byte) this.orderBy);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.areaId = reader.ReadInt();
      this.atLeastNbRoom = (uint) reader.ReadByte();
      if (this.atLeastNbRoom < 0U)
        throw new Exception("Forbidden value (" + (object) this.atLeastNbRoom + ") on element of HouseToSellFilterMessage.atLeastNbRoom.");
      this.atLeastNbChest = (uint) reader.ReadByte();
      if (this.atLeastNbChest < 0U)
        throw new Exception("Forbidden value (" + (object) this.atLeastNbChest + ") on element of HouseToSellFilterMessage.atLeastNbChest.");
      this.skillRequested = (uint) reader.ReadVarUhShort();
      if (this.skillRequested < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillRequested + ") on element of HouseToSellFilterMessage.skillRequested.");
      this.maxPrice = (double) reader.ReadVarUhLong();
      if (this.maxPrice < 0.0 || this.maxPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.maxPrice + ") on element of HouseToSellFilterMessage.maxPrice.");
      this.orderBy = (uint) reader.ReadByte();
      if (this.orderBy < 0U)
        throw new Exception("Forbidden value (" + (object) this.orderBy + ") on element of HouseToSellFilterMessage.orderBy.");
    }
  }
}
