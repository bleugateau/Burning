using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LockableShowCodeDialogMessage : NetworkMessage
  {
    public const uint Id = 5740;
    public bool changeOrUse;
    public uint codeSize;

    public override uint MessageId
    {
      get
      {
        return 5740;
      }
    }

    public LockableShowCodeDialogMessage()
    {
    }

    public LockableShowCodeDialogMessage(bool changeOrUse, uint codeSize)
    {
      this.changeOrUse = changeOrUse;
      this.codeSize = codeSize;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.changeOrUse);
      if (this.codeSize < 0U)
        throw new Exception("Forbidden value (" + (object) this.codeSize + ") on element codeSize.");
      writer.WriteByte((byte) this.codeSize);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.changeOrUse = reader.ReadBoolean();
      this.codeSize = (uint) reader.ReadByte();
      if (this.codeSize < 0U)
        throw new Exception("Forbidden value (" + (object) this.codeSize + ") on element of LockableShowCodeDialogMessage.codeSize.");
    }
  }
}
