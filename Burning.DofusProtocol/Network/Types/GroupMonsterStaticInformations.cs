using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GroupMonsterStaticInformations
  {
    public List<MonsterInGroupInformations> underlings = new List<MonsterInGroupInformations>();
    public const uint Id = 140;
    public MonsterInGroupLightInformations mainCreatureLightInfos;

    public virtual uint TypeId
    {
      get
      {
        return 140;
      }
    }

    public GroupMonsterStaticInformations()
    {
    }

    public GroupMonsterStaticInformations(
      MonsterInGroupLightInformations mainCreatureLightInfos,
      List<MonsterInGroupInformations> underlings)
    {
      this.mainCreatureLightInfos = mainCreatureLightInfos;
      this.underlings = underlings;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      this.mainCreatureLightInfos.Serialize(writer);
      writer.WriteShort((short) this.underlings.Count);
      for (int index = 0; index < this.underlings.Count; ++index)
        this.underlings[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.mainCreatureLightInfos = new MonsterInGroupLightInformations();
      this.mainCreatureLightInfos.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MonsterInGroupInformations groupInformations = new MonsterInGroupInformations();
        groupInformations.Deserialize(reader);
        this.underlings.Add(groupInformations);
      }
    }
  }
}
