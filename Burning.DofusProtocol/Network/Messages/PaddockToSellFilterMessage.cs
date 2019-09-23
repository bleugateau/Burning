using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PaddockToSellFilterMessage : NetworkMessage
  {
    public const uint Id = 6161;
    public int areaId;
    public int atLeastNbMount;
    public int atLeastNbMachine;
    public double maxPrice;
    public uint orderBy;

    public override uint MessageId
    {
      get
      {
        return 6161;
      }
    }

    public PaddockToSellFilterMessage()
    {
    }

    public PaddockToSellFilterMessage(
      int areaId,
      int atLeastNbMount,
      int atLeastNbMachine,
      double maxPrice,
      uint orderBy)
    {
      this.areaId = areaId;
      this.atLeastNbMount = atLeastNbMount;
      this.atLeastNbMachine = atLeastNbMachine;
      this.maxPrice = maxPrice;
      this.orderBy = orderBy;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.areaId);
      writer.WriteByte((byte) this.atLeastNbMount);
      writer.WriteByte((byte) this.atLeastNbMachine);
      if (this.maxPrice < 0.0 || this.maxPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.maxPrice + ") on element maxPrice.");
      writer.WriteVarLong((long) this.maxPrice);
      writer.WriteByte((byte) this.orderBy);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.areaId = reader.ReadInt();
      this.atLeastNbMount = (int) reader.ReadByte();
      this.atLeastNbMachine = (int) reader.ReadByte();
      this.maxPrice = (double) reader.ReadVarUhLong();
      if (this.maxPrice < 0.0 || this.maxPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.maxPrice + ") on element of PaddockToSellFilterMessage.maxPrice.");
      this.orderBy = (uint) reader.ReadByte();
      if (this.orderBy < 0U)
        throw new Exception("Forbidden value (" + (object) this.orderBy + ") on element of PaddockToSellFilterMessage.orderBy.");
    }
  }
}
