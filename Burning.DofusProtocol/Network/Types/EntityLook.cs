using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class EntityLook
  {
    public List<uint> skins = new List<uint>();
    public List<int> indexedColors = new List<int>();
    public List<int> scales = new List<int>();
    public List<SubEntity> subentities = new List<SubEntity>();
    public const uint Id = 55;
    public uint bonesId;

    public virtual uint TypeId
    {
      get
      {
        return 55;
      }
    }

    public EntityLook()
    {
    }

    public EntityLook(
      uint bonesId,
      List<uint> skins,
      List<int> indexedColors,
      List<int> scales,
      List<SubEntity> subentities)
    {
      this.bonesId = bonesId;
      this.skins = skins;
      this.indexedColors = indexedColors;
      this.scales = scales;
      this.subentities = subentities;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.bonesId < 0U)
        throw new Exception("Forbidden value (" + (object) this.bonesId + ") on element bonesId.");
      writer.WriteVarShort((short) this.bonesId);
      writer.WriteShort((short) this.skins.Count);
      for (int index = 0; index < this.skins.Count; ++index)
      {
        if (this.skins[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.skins[index] + ") on element 2 (starting at 1) of skins.");
        writer.WriteVarShort((short) this.skins[index]);
      }
      writer.WriteShort((short) this.indexedColors.Count);
      for (int index = 0; index < this.indexedColors.Count; ++index)
        writer.WriteInt(this.indexedColors[index]);
      writer.WriteShort((short) this.scales.Count);
      for (int index = 0; index < this.scales.Count; ++index)
        writer.WriteVarShort((short) this.scales[index]);
      writer.WriteShort((short) this.subentities.Count);
      for (int index = 0; index < this.subentities.Count; ++index)
        this.subentities[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.bonesId = (uint) reader.ReadVarUhShort();
      if (this.bonesId < 0U)
        throw new Exception("Forbidden value (" + (object) this.bonesId + ") on element of EntityLook.bonesId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of skins.");
        this.skins.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
        this.indexedColors.Add(reader.ReadInt());
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
        this.scales.Add((int) reader.ReadVarShort());
      uint num5 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num5; ++index)
      {
        SubEntity subEntity = new SubEntity();
        subEntity.Deserialize(reader);
        this.subentities.Add(subEntity);
      }
    }
  }
}
