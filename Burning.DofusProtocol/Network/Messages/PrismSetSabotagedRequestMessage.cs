using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismSetSabotagedRequestMessage : NetworkMessage
  {
    public const uint Id = 6468;
    public uint subAreaId;

    public override uint MessageId
    {
      get
      {
        return 6468;
      }
    }

    public PrismSetSabotagedRequestMessage()
    {
    }

    public PrismSetSabotagedRequestMessage(uint subAreaId)
    {
      this.subAreaId = subAreaId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismSetSabotagedRequestMessage.subAreaId.");
    }
  }
}
