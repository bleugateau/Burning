using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class BasicNamedAllianceInformations : BasicAllianceInformations
  {
    public new const uint Id = 418;
    public string allianceName;

    public override uint TypeId
    {
      get
      {
        return 418;
      }
    }

    public BasicNamedAllianceInformations()
    {
    }

    public BasicNamedAllianceInformations(uint allianceId, string allianceTag, string allianceName)
      : base(allianceId, allianceTag)
    {
      this.allianceName = allianceName;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.allianceName);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.allianceName = reader.ReadUTF();
    }
  }
}
