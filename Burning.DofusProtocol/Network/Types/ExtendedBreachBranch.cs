using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ExtendedBreachBranch : BreachBranch
  {
    public List<MonsterInGroupLightInformations> monsters = new List<MonsterInGroupLightInformations>();
    public List<BreachReward> rewards = new List<BreachReward>();
    public new const uint Id = 560;
    public uint modifier;
    public uint prize;

    public override uint TypeId
    {
      get
      {
        return 560;
      }
    }

    public ExtendedBreachBranch()
    {
    }

    public ExtendedBreachBranch(
      uint room,
      uint element,
      List<MonsterInGroupLightInformations> bosses,
      double map,
      List<MonsterInGroupLightInformations> monsters,
      List<BreachReward> rewards,
      uint modifier,
      uint prize)
      : base(room, element, bosses, map)
    {
      this.monsters = monsters;
      this.rewards = rewards;
      this.modifier = modifier;
      this.prize = prize;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.monsters.Count);
      for (int index = 0; index < this.monsters.Count; ++index)
        this.monsters[index].Serialize(writer);
      writer.WriteShort((short) this.rewards.Count);
      for (int index = 0; index < this.rewards.Count; ++index)
        this.rewards[index].Serialize(writer);
      if (this.modifier < 0U)
        throw new Exception("Forbidden value (" + (object) this.modifier + ") on element modifier.");
      writer.WriteVarInt((int) this.modifier);
      if (this.prize < 0U)
        throw new Exception("Forbidden value (" + (object) this.prize + ") on element prize.");
      writer.WriteVarInt((int) this.prize);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        MonsterInGroupLightInformations lightInformations = new MonsterInGroupLightInformations();
        lightInformations.Deserialize(reader);
        this.monsters.Add(lightInformations);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        BreachReward breachReward = new BreachReward();
        breachReward.Deserialize(reader);
        this.rewards.Add(breachReward);
      }
      this.modifier = reader.ReadVarUhInt();
      if (this.modifier < 0U)
        throw new Exception("Forbidden value (" + (object) this.modifier + ") on element of ExtendedBreachBranch.modifier.");
      this.prize = reader.ReadVarUhInt();
      if (this.prize < 0U)
        throw new Exception("Forbidden value (" + (object) this.prize + ") on element of ExtendedBreachBranch.prize.");
    }
  }
}
