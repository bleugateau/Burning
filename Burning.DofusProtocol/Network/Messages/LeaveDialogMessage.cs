using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LeaveDialogMessage : NetworkMessage
  {
    public const uint Id = 5502;
    public uint dialogType;

    public override uint MessageId
    {
      get
      {
        return 5502;
      }
    }

    public LeaveDialogMessage()
    {
    }

    public LeaveDialogMessage(uint dialogType)
    {
      this.dialogType = dialogType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.dialogType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dialogType = (uint) reader.ReadByte();
      if (this.dialogType < 0U)
        throw new Exception("Forbidden value (" + (object) this.dialogType + ") on element of LeaveDialogMessage.dialogType.");
    }
  }
}
