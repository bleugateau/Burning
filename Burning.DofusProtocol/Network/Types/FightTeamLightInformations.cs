using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamLightInformations : AbstractFightTeamInformations
  {
    public new const uint Id = 115;
    public uint teamMembersCount;
    public uint meanLevel;
    public bool hasFriend;
    public bool hasGuildMember;
    public bool hasAllianceMember;
    public bool hasGroupMember;
    public bool hasMyTaxCollector;

    public override uint TypeId
    {
      get
      {
        return 115;
      }
    }

    public FightTeamLightInformations()
    {
    }

    public FightTeamLightInformations(
      uint teamId,
      double leaderId,
      int teamSide,
      uint teamTypeId,
      uint nbWaves,
      uint teamMembersCount,
      uint meanLevel,
      bool hasFriend,
      bool hasGuildMember,
      bool hasAllianceMember,
      bool hasGroupMember,
      bool hasMyTaxCollector)
      : base(teamId, leaderId, teamSide, teamTypeId, nbWaves)
    {
      this.teamMembersCount = teamMembersCount;
      this.meanLevel = meanLevel;
      this.hasFriend = hasFriend;
      this.hasGuildMember = hasGuildMember;
      this.hasAllianceMember = hasAllianceMember;
      this.hasGroupMember = hasGroupMember;
      this.hasMyTaxCollector = hasMyTaxCollector;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.hasFriend), (byte) 1, this.hasGuildMember), (byte) 2, this.hasAllianceMember), (byte) 3, this.hasGroupMember), (byte) 4, this.hasMyTaxCollector);
      writer.WriteByte((byte) num);
      if (this.teamMembersCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamMembersCount + ") on element teamMembersCount.");
      writer.WriteByte((byte) this.teamMembersCount);
      if (this.meanLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.meanLevel + ") on element meanLevel.");
      writer.WriteVarInt((int) this.meanLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.hasFriend = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.hasGuildMember = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.hasAllianceMember = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 2);
      this.hasGroupMember = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 3);
      this.hasMyTaxCollector = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 4);
      this.teamMembersCount = (uint) reader.ReadByte();
      if (this.teamMembersCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamMembersCount + ") on element of FightTeamLightInformations.teamMembersCount.");
      this.meanLevel = reader.ReadVarUhInt();
      if (this.meanLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.meanLevel + ") on element of FightTeamLightInformations.meanLevel.");
    }
  }
}
