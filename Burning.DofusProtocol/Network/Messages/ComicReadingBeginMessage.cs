using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ComicReadingBeginMessage : NetworkMessage
  {
    public const uint Id = 6536;
    public uint comicId;

    public override uint MessageId
    {
      get
      {
        return 6536;
      }
    }

    public ComicReadingBeginMessage()
    {
    }

    public ComicReadingBeginMessage(uint comicId)
    {
      this.comicId = comicId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.comicId < 0U)
        throw new Exception("Forbidden value (" + (object) this.comicId + ") on element comicId.");
      writer.WriteVarShort((short) this.comicId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.comicId = (uint) reader.ReadVarUhShort();
      if (this.comicId < 0U)
        throw new Exception("Forbidden value (" + (object) this.comicId + ") on element of ComicReadingBeginMessage.comicId.");
    }
  }
}
