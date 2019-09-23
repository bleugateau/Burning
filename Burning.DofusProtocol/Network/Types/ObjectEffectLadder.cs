using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectLadder : ObjectEffectCreature
  {
    public new const uint Id = 81;
    public uint monsterCount;

    public override uint TypeId
    {
      get
      {
        return 81;
      }
    }

    public ObjectEffectLadder()
    {
    }

    public ObjectEffectLadder(uint actionId, uint monsterFamilyId, uint monsterCount)
      : base(actionId, monsterFamilyId)
    {
      this.monsterCount = monsterCount;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.monsterCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterCount + ") on element monsterCount.");
      writer.WriteVarInt((int) this.monsterCount);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.monsterCount = reader.ReadVarUhInt();
      if (this.monsterCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterCount + ") on element of ObjectEffectLadder.monsterCount.");
    }
  }
}
