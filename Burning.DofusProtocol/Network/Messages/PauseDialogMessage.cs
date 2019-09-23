using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PauseDialogMessage : NetworkMessage
  {
    public const uint Id = 6012;
    public uint dialogType;

    public override uint MessageId
    {
      get
      {
        return 6012;
      }
    }

    public PauseDialogMessage()
    {
    }

    public PauseDialogMessage(uint dialogType)
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
        throw new Exception("Forbidden value (" + (object) this.dialogType + ") on element of PauseDialogMessage.dialogType.");
    }
  }
}
