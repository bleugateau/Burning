using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DocumentReadingBeginMessage : NetworkMessage
  {
    public const uint Id = 5675;
    public uint documentId;

    public override uint MessageId
    {
      get
      {
        return 5675;
      }
    }

    public DocumentReadingBeginMessage()
    {
    }

    public DocumentReadingBeginMessage(uint documentId)
    {
      this.documentId = documentId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.documentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.documentId + ") on element documentId.");
      writer.WriteVarShort((short) this.documentId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.documentId = (uint) reader.ReadVarUhShort();
      if (this.documentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.documentId + ") on element of DocumentReadingBeginMessage.documentId.");
    }
  }
}
