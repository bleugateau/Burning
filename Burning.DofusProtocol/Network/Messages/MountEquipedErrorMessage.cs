using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountEquipedErrorMessage : NetworkMessage
  {
    public const uint Id = 5963;
    public uint errorType;

    public override uint MessageId
    {
      get
      {
        return 5963;
      }
    }

    public MountEquipedErrorMessage()
    {
    }

    public MountEquipedErrorMessage(uint errorType)
    {
      this.errorType = errorType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.errorType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.errorType = (uint) reader.ReadByte();
      if (this.errorType < 0U)
        throw new Exception("Forbidden value (" + (object) this.errorType + ") on element of MountEquipedErrorMessage.errorType.");
    }
  }
}
