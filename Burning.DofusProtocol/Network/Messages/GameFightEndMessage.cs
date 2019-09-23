using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightEndMessage : NetworkMessage
  {
    public List<FightResultListEntry> results = new List<FightResultListEntry>();
    public List<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes = new List<NamedPartyTeamWithOutcome>();
    public const uint Id = 720;
    public uint duration;
    public int rewardRate;
    public int lootShareLimitMalus;

    public override uint MessageId
    {
      get
      {
        return 720;
      }
    }

    public GameFightEndMessage()
    {
    }

    public GameFightEndMessage(
      uint duration,
      int rewardRate,
      int lootShareLimitMalus,
      List<FightResultListEntry> results,
      List<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes)
    {
      this.duration = duration;
      this.rewardRate = rewardRate;
      this.lootShareLimitMalus = lootShareLimitMalus;
      this.results = results;
      this.namedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.duration < 0U)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element duration.");
      writer.WriteInt((int) this.duration);
      writer.WriteVarShort((short) this.rewardRate);
      writer.WriteShort((short) this.lootShareLimitMalus);
      writer.WriteShort((short) this.results.Count);
      for (int index = 0; index < this.results.Count; ++index)
      {
        writer.WriteShort((short) this.results[index].TypeId);
        this.results[index].Serialize(writer);
      }
      writer.WriteShort((short) this.namedPartyTeamsOutcomes.Count);
      for (int index = 0; index < this.namedPartyTeamsOutcomes.Count; ++index)
        this.namedPartyTeamsOutcomes[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.duration = (uint) reader.ReadInt();
      if (this.duration < 0U)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element of GameFightEndMessage.duration.");
      this.rewardRate = (int) reader.ReadVarShort();
      this.lootShareLimitMalus = (int) reader.ReadShort();
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        FightResultListEntry instance = ProtocolTypeManager.GetInstance<FightResultListEntry>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.results.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        NamedPartyTeamWithOutcome partyTeamWithOutcome = new NamedPartyTeamWithOutcome();
        partyTeamWithOutcome.Deserialize(reader);
        this.namedPartyTeamsOutcomes.Add(partyTeamWithOutcome);
      }
    }
  }
}
