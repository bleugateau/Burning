using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightCommonInformations
  {
    public List<FightTeamInformations> fightTeams = new List<FightTeamInformations>();
    public List<uint> fightTeamsPositions = new List<uint>();
    public List<FightOptionsInformations> fightTeamsOptions = new List<FightOptionsInformations>();
    public const uint Id = 43;
    public uint fightId;
    public uint fightType;

    public virtual uint TypeId
    {
      get
      {
        return 43;
      }
    }

    public FightCommonInformations()
    {
    }

    public FightCommonInformations(
      uint fightId,
      uint fightType,
      List<FightTeamInformations> fightTeams,
      List<uint> fightTeamsPositions,
      List<FightOptionsInformations> fightTeamsOptions)
    {
      this.fightId = fightId;
      this.fightType = fightType;
      this.fightTeams = fightTeams;
      this.fightTeamsPositions = fightTeamsPositions;
      this.fightTeamsOptions = fightTeamsOptions;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteByte((byte) this.fightType);
      writer.WriteShort((short) this.fightTeams.Count);
      for (int index = 0; index < this.fightTeams.Count; ++index)
      {
        writer.WriteShort((short) this.fightTeams[index].TypeId);
        this.fightTeams[index].Serialize(writer);
      }
      writer.WriteShort((short) this.fightTeamsPositions.Count);
      for (int index = 0; index < this.fightTeamsPositions.Count; ++index)
      {
        if (this.fightTeamsPositions[index] < 0U || this.fightTeamsPositions[index] > 559U)
          throw new Exception("Forbidden value (" + (object) this.fightTeamsPositions[index] + ") on element 4 (starting at 1) of fightTeamsPositions.");
        writer.WriteVarShort((short) this.fightTeamsPositions[index]);
      }
      writer.WriteShort((short) this.fightTeamsOptions.Count);
      for (int index = 0; index < this.fightTeamsOptions.Count; ++index)
        this.fightTeamsOptions[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of FightCommonInformations.fightId.");
      this.fightType = (uint) reader.ReadByte();
      if (this.fightType < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightType + ") on element of FightCommonInformations.fightType.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        FightTeamInformations instance = ProtocolTypeManager.GetInstance<FightTeamInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.fightTeams.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        uint num3 = (uint) reader.ReadVarUhShort();
        if (num3 < 0U || num3 > 559U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of fightTeamsPositions.");
        this.fightTeamsPositions.Add(num3);
      }
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        FightOptionsInformations optionsInformations = new FightOptionsInformations();
        optionsInformations.Deserialize(reader);
        this.fightTeamsOptions.Add(optionsInformations);
      }
    }
  }
}
