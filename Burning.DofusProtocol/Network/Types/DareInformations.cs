using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class DareInformations
  {
    public List<DareCriteria> criterions = new List<DareCriteria>();
    public const uint Id = 502;
    public double dareId;
    public CharacterBasicMinimalInformations creator;
    public double subscriptionFee;
    public double jackpot;
    public uint maxCountWinners;
    public double endDate;
    public bool isPrivate;
    public uint guildId;
    public uint allianceId;
    public double startDate;

    public virtual uint TypeId
    {
      get
      {
        return 502;
      }
    }

    public DareInformations()
    {
    }

    public DareInformations(
      double dareId,
      CharacterBasicMinimalInformations creator,
      double subscriptionFee,
      double jackpot,
      uint maxCountWinners,
      double endDate,
      bool isPrivate,
      uint guildId,
      uint allianceId,
      List<DareCriteria> criterions,
      double startDate)
    {
      this.dareId = dareId;
      this.creator = creator;
      this.subscriptionFee = subscriptionFee;
      this.jackpot = jackpot;
      this.maxCountWinners = maxCountWinners;
      this.endDate = endDate;
      this.isPrivate = isPrivate;
      this.guildId = guildId;
      this.allianceId = allianceId;
      this.criterions = criterions;
      this.startDate = startDate;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element dareId.");
      writer.WriteDouble(this.dareId);
      this.creator.Serialize(writer);
      if (this.subscriptionFee < 0.0 || this.subscriptionFee > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionFee + ") on element subscriptionFee.");
      writer.WriteVarLong((long) this.subscriptionFee);
      if (this.jackpot < 0.0 || this.jackpot > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jackpot + ") on element jackpot.");
      writer.WriteVarLong((long) this.jackpot);
      if (this.maxCountWinners < 0U || this.maxCountWinners > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.maxCountWinners + ") on element maxCountWinners.");
      writer.WriteShort((short) this.maxCountWinners);
      if (this.endDate < 0.0 || this.endDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.endDate + ") on element endDate.");
      writer.WriteDouble(this.endDate);
      writer.WriteBoolean(this.isPrivate);
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element guildId.");
      writer.WriteVarInt((int) this.guildId);
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element allianceId.");
      writer.WriteVarInt((int) this.allianceId);
      writer.WriteShort((short) this.criterions.Count);
      for (int index = 0; index < this.criterions.Count; ++index)
        this.criterions[index].Serialize(writer);
      if (this.startDate < 0.0 || this.startDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.startDate + ") on element startDate.");
      writer.WriteDouble(this.startDate);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.dareId = reader.ReadDouble();
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element of DareInformations.dareId.");
      this.creator = new CharacterBasicMinimalInformations();
      this.creator.Deserialize(reader);
      this.subscriptionFee = (double) reader.ReadVarUhLong();
      if (this.subscriptionFee < 0.0 || this.subscriptionFee > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionFee + ") on element of DareInformations.subscriptionFee.");
      this.jackpot = (double) reader.ReadVarUhLong();
      if (this.jackpot < 0.0 || this.jackpot > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jackpot + ") on element of DareInformations.jackpot.");
      this.maxCountWinners = (uint) reader.ReadUShort();
      if (this.maxCountWinners < 0U || this.maxCountWinners > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.maxCountWinners + ") on element of DareInformations.maxCountWinners.");
      this.endDate = reader.ReadDouble();
      if (this.endDate < 0.0 || this.endDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.endDate + ") on element of DareInformations.endDate.");
      this.isPrivate = reader.ReadBoolean();
      this.guildId = reader.ReadVarUhInt();
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of DareInformations.guildId.");
      this.allianceId = reader.ReadVarUhInt();
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element of DareInformations.allianceId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        DareCriteria dareCriteria = new DareCriteria();
        dareCriteria.Deserialize(reader);
        this.criterions.Add(dareCriteria);
      }
      this.startDate = reader.ReadDouble();
      if (this.startDate < 0.0 || this.startDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.startDate + ") on element of DareInformations.startDate.");
    }
  }
}
