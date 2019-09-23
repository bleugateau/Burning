using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class RemodelingInformation
  {
    public List<int> colors = new List<int>();
    public const uint Id = 480;
    public string name;
    public int breed;
    public bool sex;
    public uint cosmeticId;

    public virtual uint TypeId
    {
      get
      {
        return 480;
      }
    }

    public RemodelingInformation()
    {
    }

    public RemodelingInformation(
      string name,
      int breed,
      bool sex,
      uint cosmeticId,
      List<int> colors)
    {
      this.name = name;
      this.breed = breed;
      this.sex = sex;
      this.cosmeticId = cosmeticId;
      this.colors = colors;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
      if (this.cosmeticId < 0U)
        throw new Exception("Forbidden value (" + (object) this.cosmeticId + ") on element cosmeticId.");
      writer.WriteVarShort((short) this.cosmeticId);
      writer.WriteShort((short) this.colors.Count);
      for (int index = 0; index < this.colors.Count; ++index)
        writer.WriteInt(this.colors[index]);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.name = reader.ReadUTF();
      this.breed = (int) reader.ReadByte();
      this.sex = reader.ReadBoolean();
      this.cosmeticId = (uint) reader.ReadVarUhShort();
      if (this.cosmeticId < 0U)
        throw new Exception("Forbidden value (" + (object) this.cosmeticId + ") on element of RemodelingInformation.cosmeticId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.colors.Add(reader.ReadInt());
    }
  }
}
