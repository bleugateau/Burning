using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AllianceFactSheetInformations : AllianceInformations
  {
    public new const uint Id = 421;
    public uint creationDate;

    public override uint TypeId
    {
      get
      {
        return 421;
      }
    }

    public AllianceFactSheetInformations()
    {
    }

    public AllianceFactSheetInformations(
      uint allianceId,
      string allianceTag,
      string allianceName,
      GuildEmblem allianceEmblem,
      uint creationDate)
      : base(allianceId, allianceTag, allianceName, allianceEmblem)
    {
      this.creationDate = creationDate;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.creationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.creationDate + ") on element creationDate.");
      writer.WriteInt((int) this.creationDate);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.creationDate = (uint) reader.ReadInt();
      if (this.creationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.creationDate + ") on element of AllianceFactSheetInformations.creationDate.");
    }
  }
}
