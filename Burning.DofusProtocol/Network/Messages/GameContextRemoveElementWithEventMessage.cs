using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
  {
    public new const uint Id = 6412;
    public uint elementEventId;

    public override uint MessageId
    {
      get
      {
        return 6412;
      }
    }

    public GameContextRemoveElementWithEventMessage()
    {
    }

    public GameContextRemoveElementWithEventMessage(double id, uint elementEventId)
      : base(id)
    {
      this.elementEventId = elementEventId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.elementEventId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementEventId + ") on element elementEventId.");
      writer.WriteByte((byte) this.elementEventId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.elementEventId = (uint) reader.ReadByte();
      if (this.elementEventId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementEventId + ") on element of GameContextRemoveElementWithEventMessage.elementEventId.");
    }
  }
}
