using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultExperienceData : FightResultAdditionalData
  {
    public new const uint Id = 192;
    public double experience;
    public bool showExperience;
    public double experienceLevelFloor;
    public bool showExperienceLevelFloor;
    public double experienceNextLevelFloor;
    public bool showExperienceNextLevelFloor;
    public double experienceFightDelta;
    public bool showExperienceFightDelta;
    public double experienceForGuild;
    public bool showExperienceForGuild;
    public double experienceForMount;
    public bool showExperienceForMount;
    public bool isIncarnationExperience;
    public uint rerollExperienceMul;

    public override uint TypeId
    {
      get
      {
        return 192;
      }
    }

    public FightResultExperienceData()
    {
    }

    public FightResultExperienceData(
      double experience,
      bool showExperience,
      double experienceLevelFloor,
      bool showExperienceLevelFloor,
      double experienceNextLevelFloor,
      bool showExperienceNextLevelFloor,
      double experienceFightDelta,
      bool showExperienceFightDelta,
      double experienceForGuild,
      bool showExperienceForGuild,
      double experienceForMount,
      bool showExperienceForMount,
      bool isIncarnationExperience,
      uint rerollExperienceMul)
    {
      this.experience = experience;
      this.showExperience = showExperience;
      this.experienceLevelFloor = experienceLevelFloor;
      this.showExperienceLevelFloor = showExperienceLevelFloor;
      this.experienceNextLevelFloor = experienceNextLevelFloor;
      this.showExperienceNextLevelFloor = showExperienceNextLevelFloor;
      this.experienceFightDelta = experienceFightDelta;
      this.showExperienceFightDelta = showExperienceFightDelta;
      this.experienceForGuild = experienceForGuild;
      this.showExperienceForGuild = showExperienceForGuild;
      this.experienceForMount = experienceForMount;
      this.showExperienceForMount = showExperienceForMount;
      this.isIncarnationExperience = isIncarnationExperience;
      this.rerollExperienceMul = rerollExperienceMul;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.showExperience), (byte) 1, this.showExperienceLevelFloor), (byte) 2, this.showExperienceNextLevelFloor), (byte) 3, this.showExperienceFightDelta), (byte) 4, this.showExperienceForGuild), (byte) 5, this.showExperienceForMount), (byte) 6, this.isIncarnationExperience);
      writer.WriteByte((byte) num);
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteVarLong((long) this.experience);
      if (this.experienceLevelFloor < 0.0 || this.experienceLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceLevelFloor + ") on element experienceLevelFloor.");
      writer.WriteVarLong((long) this.experienceLevelFloor);
      if (this.experienceNextLevelFloor < 0.0 || this.experienceNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceNextLevelFloor + ") on element experienceNextLevelFloor.");
      writer.WriteVarLong((long) this.experienceNextLevelFloor);
      if (this.experienceFightDelta < 0.0 || this.experienceFightDelta > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceFightDelta + ") on element experienceFightDelta.");
      writer.WriteVarLong((long) this.experienceFightDelta);
      if (this.experienceForGuild < 0.0 || this.experienceForGuild > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForGuild + ") on element experienceForGuild.");
      writer.WriteVarLong((long) this.experienceForGuild);
      if (this.experienceForMount < 0.0 || this.experienceForMount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForMount + ") on element experienceForMount.");
      writer.WriteVarLong((long) this.experienceForMount);
      if (this.rerollExperienceMul < 0U)
        throw new Exception("Forbidden value (" + (object) this.rerollExperienceMul + ") on element rerollExperienceMul.");
      writer.WriteByte((byte) this.rerollExperienceMul);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.showExperience = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.showExperienceLevelFloor = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.showExperienceNextLevelFloor = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 2);
      this.showExperienceFightDelta = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 3);
      this.showExperienceForGuild = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 4);
      this.showExperienceForMount = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 5);
      this.isIncarnationExperience = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 6);
      this.experience = (double) reader.ReadVarUhLong();
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of FightResultExperienceData.experience.");
      this.experienceLevelFloor = (double) reader.ReadVarUhLong();
      if (this.experienceLevelFloor < 0.0 || this.experienceLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceLevelFloor + ") on element of FightResultExperienceData.experienceLevelFloor.");
      this.experienceNextLevelFloor = (double) reader.ReadVarUhLong();
      if (this.experienceNextLevelFloor < 0.0 || this.experienceNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceNextLevelFloor + ") on element of FightResultExperienceData.experienceNextLevelFloor.");
      this.experienceFightDelta = (double) reader.ReadVarUhLong();
      if (this.experienceFightDelta < 0.0 || this.experienceFightDelta > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceFightDelta + ") on element of FightResultExperienceData.experienceFightDelta.");
      this.experienceForGuild = (double) reader.ReadVarUhLong();
      if (this.experienceForGuild < 0.0 || this.experienceForGuild > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForGuild + ") on element of FightResultExperienceData.experienceForGuild.");
      this.experienceForMount = (double) reader.ReadVarUhLong();
      if (this.experienceForMount < 0.0 || this.experienceForMount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceForMount + ") on element of FightResultExperienceData.experienceForMount.");
      this.rerollExperienceMul = (uint) reader.ReadByte();
      if (this.rerollExperienceMul < 0U)
        throw new Exception("Forbidden value (" + (object) this.rerollExperienceMul + ") on element of FightResultExperienceData.rerollExperienceMul.");
    }
  }
}
