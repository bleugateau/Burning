using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismSetSabotagedRefusedMessage : NetworkMessage
  {
    public const uint Id = 6466;
    public uint subAreaId;
    public int reason;

    public override uint MessageId
    {
      get
      {
        return 6466;
      }
    }

    public PrismSetSabotagedRefusedMessage()
    {
    }

    public PrismSetSabotagedRefusedMessage(uint subAreaId, int reason)
    {
      this.subAreaId = subAreaId;
      this.reason = reason;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteByte((byte) this.reason);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismSetSabotagedRefusedMessage.subAreaId.");
      this.reason = (int) reader.ReadByte();
    }
  }
}
