using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildGetInformationsMessage : NetworkMessage
  {
    public const uint Id = 5550;
    public uint infoType;

    public override uint MessageId
    {
      get
      {
        return 5550;
      }
    }

    public GuildGetInformationsMessage()
    {
    }

    public GuildGetInformationsMessage(uint infoType)
    {
      this.infoType = infoType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.infoType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.infoType = (uint) reader.ReadByte();
      if (this.infoType < 0U)
        throw new Exception("Forbidden value (" + (object) this.infoType + ") on element of GuildGetInformationsMessage.infoType.");
    }
  }
}
