using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5570;
    public int markId;

    public override uint MessageId
    {
      get
      {
        return 5570;
      }
    }

    public GameActionFightUnmarkCellsMessage()
    {
    }

    public GameActionFightUnmarkCellsMessage(uint actionId, double sourceId, int markId)
      : base(actionId, sourceId)
    {
      this.markId = markId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.markId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.markId = (int) reader.ReadShort();
    }
  }
}
