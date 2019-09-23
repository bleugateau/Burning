using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceModificationValidMessage : NetworkMessage
  {
    public const uint Id = 6450;
    public string allianceName;
    public string allianceTag;
    public GuildEmblem Alliancemblem;

    public override uint MessageId
    {
      get
      {
        return 6450;
      }
    }

    public AllianceModificationValidMessage()
    {
    }

    public AllianceModificationValidMessage(
      string allianceName,
      string allianceTag,
      GuildEmblem Alliancemblem)
    {
      this.allianceName = allianceName;
      this.allianceTag = allianceTag;
      this.Alliancemblem = Alliancemblem;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.allianceName);
      writer.WriteUTF(this.allianceTag);
      this.Alliancemblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.allianceName = reader.ReadUTF();
      this.allianceTag = reader.ReadUTF();
      this.Alliancemblem = new GuildEmblem();
      this.Alliancemblem.Deserialize(reader);
    }
  }
}
