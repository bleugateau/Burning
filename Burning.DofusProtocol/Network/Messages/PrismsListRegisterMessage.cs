using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismsListRegisterMessage : NetworkMessage
  {
    public const uint Id = 6441;
    public uint listen;

    public override uint MessageId
    {
      get
      {
        return 6441;
      }
    }

    public PrismsListRegisterMessage()
    {
    }

    public PrismsListRegisterMessage(uint listen)
    {
      this.listen = listen;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.listen);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.listen = (uint) reader.ReadByte();
      if (this.listen < 0U)
        throw new Exception("Forbidden value (" + (object) this.listen + ") on element of PrismsListRegisterMessage.listen.");
    }
  }
}
