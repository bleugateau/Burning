using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatClientMultiMessage : ChatAbstractClientMessage
  {
    public new const uint Id = 861;
    public uint channel;

    public override uint MessageId
    {
      get
      {
        return 861;
      }
    }

    public ChatClientMultiMessage()
    {
    }

    public ChatClientMultiMessage(string content, uint channel)
      : base(content)
    {
      this.channel = channel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.channel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.channel = (uint) reader.ReadByte();
      if (this.channel < 0U)
        throw new Exception("Forbidden value (" + (object) this.channel + ") on element of ChatClientMultiMessage.channel.");
    }
  }
}
