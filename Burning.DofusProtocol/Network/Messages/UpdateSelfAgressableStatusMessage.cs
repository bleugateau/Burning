using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class UpdateSelfAgressableStatusMessage : NetworkMessage
  {
    public const uint Id = 6456;
    public uint status;
    public uint probationTime;

    public override uint MessageId
    {
      get
      {
        return 6456;
      }
    }

    public UpdateSelfAgressableStatusMessage()
    {
    }

    public UpdateSelfAgressableStatusMessage(uint status, uint probationTime)
    {
      this.status = status;
      this.probationTime = probationTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.status);
      if (this.probationTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.probationTime + ") on element probationTime.");
      writer.WriteInt((int) this.probationTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.status = (uint) reader.ReadByte();
      if (this.status < 0U)
        throw new Exception("Forbidden value (" + (object) this.status + ") on element of UpdateSelfAgressableStatusMessage.status.");
      this.probationTime = (uint) reader.ReadInt();
      if (this.probationTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.probationTime + ") on element of UpdateSelfAgressableStatusMessage.probationTime.");
    }
  }
}
