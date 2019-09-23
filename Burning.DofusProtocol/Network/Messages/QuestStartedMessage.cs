using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class QuestStartedMessage : NetworkMessage
  {
    public const uint Id = 6091;
    public uint questId;

    public override uint MessageId
    {
      get
      {
        return 6091;
      }
    }

    public QuestStartedMessage()
    {
    }

    public QuestStartedMessage(uint questId)
    {
      this.questId = questId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element questId.");
      writer.WriteVarShort((short) this.questId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questId = (uint) reader.ReadVarUhShort();
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element of QuestStartedMessage.questId.");
    }
  }
}
