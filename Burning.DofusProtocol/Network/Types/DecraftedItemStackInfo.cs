using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class DecraftedItemStackInfo
  {
    public List<uint> runesId = new List<uint>();
    public List<uint> runesQty = new List<uint>();
    public const uint Id = 481;
    public uint objectUID;
    public double bonusMin;
    public double bonusMax;

    public virtual uint TypeId
    {
      get
      {
        return 481;
      }
    }

    public DecraftedItemStackInfo()
    {
    }

    public DecraftedItemStackInfo(
      uint objectUID,
      double bonusMin,
      double bonusMax,
      List<uint> runesId,
      List<uint> runesQty)
    {
      this.objectUID = objectUID;
      this.bonusMin = bonusMin;
      this.bonusMax = bonusMax;
      this.runesId = runesId;
      this.runesQty = runesQty;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      writer.WriteFloat((float) this.bonusMin);
      writer.WriteFloat((float) this.bonusMax);
      writer.WriteShort((short) this.runesId.Count);
      for (int index = 0; index < this.runesId.Count; ++index)
      {
        if (this.runesId[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.runesId[index] + ") on element 4 (starting at 1) of runesId.");
        writer.WriteVarShort((short) this.runesId[index]);
      }
      writer.WriteShort((short) this.runesQty.Count);
      for (int index = 0; index < this.runesQty.Count; ++index)
      {
        if (this.runesQty[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.runesQty[index] + ") on element 5 (starting at 1) of runesQty.");
        writer.WriteVarInt((int) this.runesQty[index]);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of DecraftedItemStackInfo.objectUID.");
      this.bonusMin = (double) reader.ReadFloat();
      this.bonusMax = (double) reader.ReadFloat();
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of runesId.");
        this.runesId.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of runesQty.");
        this.runesQty.Add(num2);
      }
    }
  }
}
