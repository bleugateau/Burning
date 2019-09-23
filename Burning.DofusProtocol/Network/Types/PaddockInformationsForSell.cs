using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PaddockInformationsForSell
  {
    public const uint Id = 222;
    public string guildOwner;
    public int worldX;
    public int worldY;
    public uint subAreaId;
    public int nbMount;
    public int nbObject;
    public double price;

    public virtual uint TypeId
    {
      get
      {
        return 222;
      }
    }

    public PaddockInformationsForSell()
    {
    }

    public PaddockInformationsForSell(
      string guildOwner,
      int worldX,
      int worldY,
      uint subAreaId,
      int nbMount,
      int nbObject,
      double price)
    {
      this.guildOwner = guildOwner;
      this.worldX = worldX;
      this.worldY = worldY;
      this.subAreaId = subAreaId;
      this.nbMount = nbMount;
      this.nbObject = nbObject;
      this.price = price;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.guildOwner);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteByte((byte) this.nbMount);
      writer.WriteByte((byte) this.nbObject);
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.guildOwner = reader.ReadUTF();
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of PaddockInformationsForSell.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of PaddockInformationsForSell.worldY.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PaddockInformationsForSell.subAreaId.");
      this.nbMount = (int) reader.ReadByte();
      this.nbObject = (int) reader.ReadByte();
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of PaddockInformationsForSell.price.");
    }
  }
}
