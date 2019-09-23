using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
  {
    public new const uint Id = 177;
    public uint firstNameId;
    public uint lastNameId;
    public uint level;
    public uint guildId;
    public double uid;

    public override uint TypeId
    {
      get
      {
        return 177;
      }
    }

    public FightTeamMemberTaxCollectorInformations()
    {
    }

    public FightTeamMemberTaxCollectorInformations(
      double id,
      uint firstNameId,
      uint lastNameId,
      uint level,
      uint guildId,
      double uid)
      : base(id)
    {
      this.firstNameId = firstNameId;
      this.lastNameId = lastNameId;
      this.level = level;
      this.guildId = guildId;
      this.uid = uid;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element firstNameId.");
      writer.WriteVarShort((short) this.firstNameId);
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element lastNameId.");
      writer.WriteVarShort((short) this.lastNameId);
      if (this.level < 1U || this.level > 200U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteByte((byte) this.level);
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element guildId.");
      writer.WriteVarInt((int) this.guildId);
      if (this.uid < 0.0 || this.uid > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element uid.");
      writer.WriteDouble(this.uid);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.firstNameId = (uint) reader.ReadVarUhShort();
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element of FightTeamMemberTaxCollectorInformations.firstNameId.");
      this.lastNameId = (uint) reader.ReadVarUhShort();
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element of FightTeamMemberTaxCollectorInformations.lastNameId.");
      this.level = (uint) reader.ReadByte();
      if (this.level < 1U || this.level > 200U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of FightTeamMemberTaxCollectorInformations.level.");
      this.guildId = reader.ReadVarUhInt();
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of FightTeamMemberTaxCollectorInformations.guildId.");
      this.uid = reader.ReadDouble();
      if (this.uid < 0.0 || this.uid > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element of FightTeamMemberTaxCollectorInformations.uid.");
    }
  }
}
