using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightActivateGlyphTrapMessage : AbstractGameActionMessage
  {
    public new const uint Id = 6545;
    public int markId;
    public bool active;

    public override uint MessageId
    {
      get
      {
        return 6545;
      }
    }

    public GameActionFightActivateGlyphTrapMessage()
    {
    }

    public GameActionFightActivateGlyphTrapMessage(
      uint actionId,
      double sourceId,
      int markId,
      bool active)
      : base(actionId, sourceId)
    {
      this.markId = markId;
      this.active = active;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.markId);
      writer.WriteBoolean(this.active);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.markId = (int) reader.ReadShort();
      this.active = reader.ReadBoolean();
    }
  }
}
