using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightSpectateMessage : NetworkMessage
  {
    public List<FightDispellableEffectExtendedInformations> effects = new List<FightDispellableEffectExtendedInformations>();
    public List<GameActionMark> marks = new List<GameActionMark>();
    public List<Idol> idols = new List<Idol>();
    public List<GameFightEffectTriggerCount> fxTriggerCounts = new List<GameFightEffectTriggerCount>();
    public const uint Id = 6069;
    public uint gameTurn;
    public uint fightStart;

    public override uint MessageId
    {
      get
      {
        return 6069;
      }
    }

    public GameFightSpectateMessage()
    {
    }

    public GameFightSpectateMessage(
      List<FightDispellableEffectExtendedInformations> effects,
      List<GameActionMark> marks,
      uint gameTurn,
      uint fightStart,
      List<Idol> idols,
      List<GameFightEffectTriggerCount> fxTriggerCounts)
    {
      this.effects = effects;
      this.marks = marks;
      this.gameTurn = gameTurn;
      this.fightStart = fightStart;
      this.idols = idols;
      this.fxTriggerCounts = fxTriggerCounts;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.effects.Count);
      for (int index = 0; index < this.effects.Count; ++index)
        this.effects[index].Serialize(writer);
      writer.WriteShort((short) this.marks.Count);
      for (int index = 0; index < this.marks.Count; ++index)
        this.marks[index].Serialize(writer);
      if (this.gameTurn < 0U)
        throw new Exception("Forbidden value (" + (object) this.gameTurn + ") on element gameTurn.");
      writer.WriteVarShort((short) this.gameTurn);
      if (this.fightStart < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightStart + ") on element fightStart.");
      writer.WriteInt((int) this.fightStart);
      writer.WriteShort((short) this.idols.Count);
      for (int index = 0; index < this.idols.Count; ++index)
        this.idols[index].Serialize(writer);
      writer.WriteShort((short) this.fxTriggerCounts.Count);
      for (int index = 0; index < this.fxTriggerCounts.Count; ++index)
        this.fxTriggerCounts[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        FightDispellableEffectExtendedInformations extendedInformations = new FightDispellableEffectExtendedInformations();
        extendedInformations.Deserialize(reader);
        this.effects.Add(extendedInformations);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        GameActionMark gameActionMark = new GameActionMark();
        gameActionMark.Deserialize(reader);
        this.marks.Add(gameActionMark);
      }
      this.gameTurn = (uint) reader.ReadVarUhShort();
      if (this.gameTurn < 0U)
        throw new Exception("Forbidden value (" + (object) this.gameTurn + ") on element of GameFightSpectateMessage.gameTurn.");
      this.fightStart = (uint) reader.ReadInt();
      if (this.fightStart < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightStart + ") on element of GameFightSpectateMessage.fightStart.");
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        Idol idol = new Idol();
        idol.Deserialize(reader);
        this.idols.Add(idol);
      }
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        GameFightEffectTriggerCount effectTriggerCount = new GameFightEffectTriggerCount();
        effectTriggerCount.Deserialize(reader);
        this.fxTriggerCounts.Add(effectTriggerCount);
      }
    }
  }
}
