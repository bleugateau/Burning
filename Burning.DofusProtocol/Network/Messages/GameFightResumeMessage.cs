using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightResumeMessage : GameFightSpectateMessage
  {
    public List<GameFightSpellCooldown> spellCooldowns = new List<GameFightSpellCooldown>();
    public new const uint Id = 6067;
    public uint summonCount;
    public uint bombCount;

    public override uint MessageId
    {
      get
      {
        return 6067;
      }
    }

    public GameFightResumeMessage()
    {
    }

    public GameFightResumeMessage(
      List<FightDispellableEffectExtendedInformations> effects,
      List<GameActionMark> marks,
      uint gameTurn,
      uint fightStart,
      List<Idol> idols,
      List<GameFightEffectTriggerCount> fxTriggerCounts,
      List<GameFightSpellCooldown> spellCooldowns,
      uint summonCount,
      uint bombCount)
      : base(effects, marks, gameTurn, fightStart, idols, fxTriggerCounts)
    {
      this.spellCooldowns = spellCooldowns;
      this.summonCount = summonCount;
      this.bombCount = bombCount;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.spellCooldowns.Count);
      for (int index = 0; index < this.spellCooldowns.Count; ++index)
        this.spellCooldowns[index].Serialize(writer);
      if (this.summonCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.summonCount + ") on element summonCount.");
      writer.WriteByte((byte) this.summonCount);
      if (this.bombCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.bombCount + ") on element bombCount.");
      writer.WriteByte((byte) this.bombCount);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameFightSpellCooldown fightSpellCooldown = new GameFightSpellCooldown();
        fightSpellCooldown.Deserialize(reader);
        this.spellCooldowns.Add(fightSpellCooldown);
      }
      this.summonCount = (uint) reader.ReadByte();
      if (this.summonCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.summonCount + ") on element of GameFightResumeMessage.summonCount.");
      this.bombCount = (uint) reader.ReadByte();
      if (this.bombCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.bombCount + ") on element of GameFightResumeMessage.bombCount.");
    }
  }
}
