using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class AlternativeMonstersInGroupLightInformations
  {
    public List<MonsterInGroupLightInformations> monsters = new List<MonsterInGroupLightInformations>();
    public const uint Id = 394;
    public int playerCount;

    public virtual uint TypeId
    {
      get
      {
        return 394;
      }
    }

    public AlternativeMonstersInGroupLightInformations()
    {
    }

    public AlternativeMonstersInGroupLightInformations(
      int playerCount,
      List<MonsterInGroupLightInformations> monsters)
    {
      this.playerCount = playerCount;
      this.monsters = monsters;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.playerCount);
      writer.WriteShort((short) this.monsters.Count);
      for (int index = 0; index < this.monsters.Count; ++index)
        this.monsters[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.playerCount = reader.ReadInt();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MonsterInGroupLightInformations lightInformations = new MonsterInGroupLightInformations();
        lightInformations.Deserialize(reader);
        this.monsters.Add(lightInformations);
      }
    }
  }
}
