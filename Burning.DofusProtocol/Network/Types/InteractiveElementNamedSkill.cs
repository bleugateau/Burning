using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class InteractiveElementNamedSkill : InteractiveElementSkill
  {
    public new const uint Id = 220;
    public uint nameId;

    public override uint TypeId
    {
      get
      {
        return 220;
      }
    }

    public InteractiveElementNamedSkill()
    {
    }

    public InteractiveElementNamedSkill(uint skillId, uint skillInstanceUid, uint nameId)
      : base(skillId, skillInstanceUid)
    {
      this.nameId = nameId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.nameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.nameId + ") on element nameId.");
      writer.WriteVarInt((int) this.nameId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.nameId = reader.ReadVarUhInt();
      if (this.nameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.nameId + ") on element of InteractiveElementNamedSkill.nameId.");
    }
  }
}
