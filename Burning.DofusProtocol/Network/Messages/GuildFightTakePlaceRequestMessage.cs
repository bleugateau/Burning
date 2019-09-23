using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
  {
    public new const uint Id = 6235;
    public int replacedCharacterId;

    public override uint MessageId
    {
      get
      {
        return 6235;
      }
    }

    public GuildFightTakePlaceRequestMessage()
    {
    }

    public GuildFightTakePlaceRequestMessage(double taxCollectorId, int replacedCharacterId)
      : base(taxCollectorId)
    {
      this.replacedCharacterId = replacedCharacterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.replacedCharacterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.replacedCharacterId = reader.ReadInt();
    }
  }
}
