using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRefreshMonsterBoostsMessage : NetworkMessage
  {
    public List<MonsterBoosts> monsterBoosts = new List<MonsterBoosts>();
    public List<MonsterBoosts> familyBoosts = new List<MonsterBoosts>();
    public const uint Id = 6618;

    public override uint MessageId
    {
      get
      {
        return 6618;
      }
    }

    public GameRefreshMonsterBoostsMessage()
    {
    }

    public GameRefreshMonsterBoostsMessage(
      List<MonsterBoosts> monsterBoosts,
      List<MonsterBoosts> familyBoosts)
    {
      this.monsterBoosts = monsterBoosts;
      this.familyBoosts = familyBoosts;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.monsterBoosts.Count);
      for (int index = 0; index < this.monsterBoosts.Count; ++index)
        this.monsterBoosts[index].Serialize(writer);
      writer.WriteShort((short) this.familyBoosts.Count);
      for (int index = 0; index < this.familyBoosts.Count; ++index)
        this.familyBoosts[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        MonsterBoosts monsterBoosts = new MonsterBoosts();
        monsterBoosts.Deserialize(reader);
        this.monsterBoosts.Add(monsterBoosts);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        MonsterBoosts monsterBoosts = new MonsterBoosts();
        monsterBoosts.Deserialize(reader);
        this.familyBoosts.Add(monsterBoosts);
      }
    }
  }
}
