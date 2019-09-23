using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class MonsterInGroupLightInformations
  {
    public const uint Id = 395;
    public int genericId;
    public uint grade;
    public uint level;

    public virtual uint TypeId
    {
      get
      {
        return 395;
      }
    }

    public MonsterInGroupLightInformations()
    {
    }

    public MonsterInGroupLightInformations(int genericId, uint grade, uint level)
    {
      this.genericId = genericId;
      this.grade = grade;
      this.level = level;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.genericId);
      if (this.grade < 0U)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element grade.");
      writer.WriteByte((byte) this.grade);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteShort((short) this.level);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.genericId = reader.ReadInt();
      this.grade = (uint) reader.ReadByte();
      if (this.grade < 0U)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element of MonsterInGroupLightInformations.grade.");
      this.level = (uint) reader.ReadShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of MonsterInGroupLightInformations.level.");
    }
  }
}
