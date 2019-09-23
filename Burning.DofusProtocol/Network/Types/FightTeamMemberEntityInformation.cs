using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamMemberEntityInformation : FightTeamMemberInformations
  {
    public new const uint Id = 549;
    public uint entityModelId;
    public uint level;
    public double masterId;

    public override uint TypeId
    {
      get
      {
        return 549;
      }
    }

    public FightTeamMemberEntityInformation()
    {
    }

    public FightTeamMemberEntityInformation(
      double id,
      uint entityModelId,
      uint level,
      double masterId)
      : base(id)
    {
      this.entityModelId = entityModelId;
      this.level = level;
      this.masterId = masterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.entityModelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.entityModelId + ") on element entityModelId.");
      writer.WriteByte((byte) this.entityModelId);
      if (this.level < 1U || this.level > 200U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element masterId.");
      writer.WriteDouble(this.masterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.entityModelId = (uint) reader.ReadByte();
      if (this.entityModelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.entityModelId + ") on element of FightTeamMemberEntityInformation.entityModelId.");
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 1U || this.level > 200U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of FightTeamMemberEntityInformation.level.");
      this.masterId = reader.ReadDouble();
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element of FightTeamMemberEntityInformation.masterId.");
    }
  }
}
