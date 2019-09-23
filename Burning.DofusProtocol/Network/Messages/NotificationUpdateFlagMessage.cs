using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NotificationUpdateFlagMessage : NetworkMessage
  {
    public const uint Id = 6090;
    public uint index;

    public override uint MessageId
    {
      get
      {
        return 6090;
      }
    }

    public NotificationUpdateFlagMessage()
    {
    }

    public NotificationUpdateFlagMessage(uint index)
    {
      this.index = index;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element index.");
      writer.WriteVarShort((short) this.index);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.index = (uint) reader.ReadVarUhShort();
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element of NotificationUpdateFlagMessage.index.");
    }
  }
}
