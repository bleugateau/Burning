using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class URLOpenMessage : NetworkMessage
  {
    public const uint Id = 6266;
    public uint urlId;

    public override uint MessageId
    {
      get
      {
        return 6266;
      }
    }

    public URLOpenMessage()
    {
    }

    public URLOpenMessage(uint urlId)
    {
      this.urlId = urlId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.urlId < 0U)
        throw new Exception("Forbidden value (" + (object) this.urlId + ") on element urlId.");
      writer.WriteByte((byte) this.urlId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.urlId = (uint) reader.ReadByte();
      if (this.urlId < 0U)
        throw new Exception("Forbidden value (" + (object) this.urlId + ") on element of URLOpenMessage.urlId.");
    }
  }
}
