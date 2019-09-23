using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
  {
    public List<AlternativeMonstersInGroupLightInformations> alternatives = new List<AlternativeMonstersInGroupLightInformations>();
    public new const uint Id = 396;

    public override uint TypeId
    {
      get
      {
        return 396;
      }
    }

    public GroupMonsterStaticInformationsWithAlternatives()
    {
    }

    public GroupMonsterStaticInformationsWithAlternatives(
      MonsterInGroupLightInformations mainCreatureLightInfos,
      List<MonsterInGroupInformations> underlings,
      List<AlternativeMonstersInGroupLightInformations> alternatives)
      : base(mainCreatureLightInfos, underlings)
    {
      this.alternatives = alternatives;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.alternatives.Count);
      for (int index = 0; index < this.alternatives.Count; ++index)
        this.alternatives[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        AlternativeMonstersInGroupLightInformations lightInformations = new AlternativeMonstersInGroupLightInformations();
        lightInformations.Deserialize(reader);
        this.alternatives.Add(lightInformations);
      }
    }
  }
}
