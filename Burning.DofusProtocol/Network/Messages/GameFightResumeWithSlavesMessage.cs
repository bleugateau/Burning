using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
  {
    public List<GameFightResumeSlaveInfo> slavesInfo = new List<GameFightResumeSlaveInfo>();
    public new const uint Id = 6215;

    public override uint MessageId
    {
      get
      {
        return 6215;
      }
    }

    public GameFightResumeWithSlavesMessage()
    {
    }

    public GameFightResumeWithSlavesMessage(
      List<FightDispellableEffectExtendedInformations> effects,
      List<GameActionMark> marks,
      uint gameTurn,
      uint fightStart,
      List<Idol> idols,
      List<GameFightEffectTriggerCount> fxTriggerCounts,
      List<GameFightSpellCooldown> spellCooldowns,
      uint summonCount,
      uint bombCount,
      List<GameFightResumeSlaveInfo> slavesInfo)
      : base(effects, marks, gameTurn, fightStart, idols, fxTriggerCounts, spellCooldowns, summonCount, bombCount)
    {
      this.slavesInfo = slavesInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.slavesInfo.Count);
      for (int index = 0; index < this.slavesInfo.Count; ++index)
        this.slavesInfo[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameFightResumeSlaveInfo fightResumeSlaveInfo = new GameFightResumeSlaveInfo();
        fightResumeSlaveInfo.Deserialize(reader);
        this.slavesInfo.Add(fightResumeSlaveInfo);
      }
    }
  }
}
