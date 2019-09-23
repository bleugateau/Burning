using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayGroupMonsterWaveInformations : GameRolePlayGroupMonsterInformations
  {
    public List<GroupMonsterStaticInformations> alternatives = new List<GroupMonsterStaticInformations>();
    public new const uint Id = 464;
    public uint nbWaves;

    public override uint TypeId
    {
      get
      {
        return 464;
      }
    }

    public GameRolePlayGroupMonsterWaveInformations()
    {
    }

    public GameRolePlayGroupMonsterWaveInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GroupMonsterStaticInformations staticInfos,
      int lootShare,
      int alignmentSide,
      bool keyRingBonus,
      bool hasHardcoreDrop,
      bool hasAVARewardToken,
      uint nbWaves,
      List<GroupMonsterStaticInformations> alternatives)
      : base(contextualId, disposition, look, staticInfos, lootShare, alignmentSide, keyRingBonus, hasHardcoreDrop, hasAVARewardToken)
    {
      this.nbWaves = nbWaves;
      this.alternatives = alternatives;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.nbWaves < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbWaves + ") on element nbWaves.");
      writer.WriteByte((byte) this.nbWaves);
      writer.WriteShort((short) this.alternatives.Count);
      for (int index = 0; index < this.alternatives.Count; ++index)
      {
        writer.WriteShort((short) this.alternatives[index].TypeId);
        this.alternatives[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.nbWaves = (uint) reader.ReadByte();
      if (this.nbWaves < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbWaves + ") on element of GameRolePlayGroupMonsterWaveInformations.nbWaves.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GroupMonsterStaticInformations instance = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.alternatives.Add(instance);
      }
    }
  }
}
