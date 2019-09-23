using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightExternalInformations
  {
    public List<FightTeamLightInformations> fightTeams = new List<FightTeamLightInformations>();
    public List<FightOptionsInformations> fightTeamsOptions = new List<FightOptionsInformations>();
    public const uint Id = 117;
    public uint fightId;
    public uint fightType;
    public uint fightStart;
    public bool fightSpectatorLocked;

    public virtual uint TypeId
    {
      get
      {
        return 117;
      }
    }

    public FightExternalInformations()
    {
    }

    public FightExternalInformations(
      uint fightId,
      uint fightType,
      uint fightStart,
      bool fightSpectatorLocked,
      List<FightTeamLightInformations> fightTeams,
      List<FightOptionsInformations> fightTeamsOptions)
    {
      this.fightId = fightId;
      this.fightType = fightType;
      this.fightStart = fightStart;
      this.fightSpectatorLocked = fightSpectatorLocked;
      this.fightTeams = fightTeams;
      this.fightTeamsOptions = fightTeamsOptions;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteByte((byte) this.fightType);
      if (this.fightStart < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightStart + ") on element fightStart.");
      writer.WriteInt((int) this.fightStart);
      writer.WriteBoolean(this.fightSpectatorLocked);
      for (int index = 0; index < 2; ++index)
        this.fightTeams[index].Serialize(writer);
      for (int index = 0; index < 2; ++index)
        this.fightTeamsOptions[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of FightExternalInformations.fightId.");
      this.fightType = (uint) reader.ReadByte();
      if (this.fightType < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightType + ") on element of FightExternalInformations.fightType.");
      this.fightStart = (uint) reader.ReadInt();
      if (this.fightStart < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightStart + ") on element of FightExternalInformations.fightStart.");
      this.fightSpectatorLocked = reader.ReadBoolean();
      for (int index = 0; index < 2; ++index)
      {
        this.fightTeams[index] = new FightTeamLightInformations();
        this.fightTeams[index].Deserialize(reader);
      }
      for (int index = 0; index < 2; ++index)
      {
        this.fightTeamsOptions[index] = new FightOptionsInformations();
        this.fightTeamsOptions[index].Deserialize(reader);
      }
    }
  }
}
