using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectCreature : ObjectEffect
  {
    public new const uint Id = 71;
    public uint monsterFamilyId;

    public override uint TypeId
    {
      get
      {
        return 71;
      }
    }

    public ObjectEffectCreature()
    {
    }

    public ObjectEffectCreature(uint actionId, uint monsterFamilyId)
      : base(actionId)
    {
      this.monsterFamilyId = monsterFamilyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.monsterFamilyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterFamilyId + ") on element monsterFamilyId.");
      writer.WriteVarShort((short) this.monsterFamilyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.monsterFamilyId = (uint) reader.ReadVarUhShort();
      if (this.monsterFamilyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterFamilyId + ") on element of ObjectEffectCreature.monsterFamilyId.");
    }
  }
}
