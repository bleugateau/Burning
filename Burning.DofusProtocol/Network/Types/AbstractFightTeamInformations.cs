using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AbstractFightTeamInformations
  {
    public const uint Id = 116;
    public uint teamId;
    public double leaderId;
    public int teamSide;
    public uint teamTypeId;
    public uint nbWaves;

    public virtual uint TypeId
    {
      get
      {
        return 116;
      }
    }

    public AbstractFightTeamInformations()
    {
    }

    public AbstractFightTeamInformations(
      uint teamId,
      double leaderId,
      int teamSide,
      uint teamTypeId,
      uint nbWaves)
    {
      this.teamId = teamId;
      this.leaderId = leaderId;
      this.teamSide = teamSide;
      this.teamTypeId = teamTypeId;
      this.nbWaves = nbWaves;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.teamId);
      if (this.leaderId < -9.00719925474099E+15 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element leaderId.");
      writer.WriteDouble(this.leaderId);
      writer.WriteByte((byte) this.teamSide);
      writer.WriteByte((byte) this.teamTypeId);
      if (this.nbWaves < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbWaves + ") on element nbWaves.");
      writer.WriteByte((byte) this.nbWaves);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.teamId = (uint) reader.ReadByte();
      if (this.teamId < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamId + ") on element of AbstractFightTeamInformations.teamId.");
      this.leaderId = reader.ReadDouble();
      if (this.leaderId < -9.00719925474099E+15 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element of AbstractFightTeamInformations.leaderId.");
      this.teamSide = (int) reader.ReadByte();
      this.teamTypeId = (uint) reader.ReadByte();
      if (this.teamTypeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamTypeId + ") on element of AbstractFightTeamInformations.teamTypeId.");
      this.nbWaves = (uint) reader.ReadByte();
      if (this.nbWaves < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbWaves + ") on element of AbstractFightTeamInformations.nbWaves.");
    }
  }
}
