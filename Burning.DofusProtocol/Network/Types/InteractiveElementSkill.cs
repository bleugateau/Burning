using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class InteractiveElementSkill
  {
    public const uint Id = 219;
    public uint skillId;
    public uint skillInstanceUid;

    public virtual uint TypeId
    {
      get
      {
        return 219;
      }
    }

    public InteractiveElementSkill()
    {
    }

    public InteractiveElementSkill(uint skillId, uint skillInstanceUid)
    {
      this.skillId = skillId;
      this.skillInstanceUid = skillInstanceUid;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarInt((int) this.skillId);
      if (this.skillInstanceUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillInstanceUid + ") on element skillInstanceUid.");
      writer.WriteInt((int) this.skillInstanceUid);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.skillId = reader.ReadVarUhInt();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of InteractiveElementSkill.skillId.");
      this.skillInstanceUid = (uint) reader.ReadInt();
      if (this.skillInstanceUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillInstanceUid + ") on element of InteractiveElementSkill.skillInstanceUid.");
    }
  }
}
