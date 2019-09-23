using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
  {
    public new const uint Id = 1001;
    public int waitAckId;

    public override uint MessageId
    {
      get
      {
        return 1001;
      }
    }

    public AbstractGameActionWithAckMessage()
    {
    }

    public AbstractGameActionWithAckMessage(uint actionId, double sourceId, int waitAckId)
      : base(actionId, sourceId)
    {
      this.waitAckId = waitAckId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.waitAckId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.waitAckId = (int) reader.ReadShort();
    }
  }
}
