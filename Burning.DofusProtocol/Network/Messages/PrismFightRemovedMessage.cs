using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightRemovedMessage : NetworkMessage
  {
    public const uint Id = 6453;
    public uint subAreaId;

    public override uint MessageId
    {
      get
      {
        return 6453;
      }
    }

    public PrismFightRemovedMessage()
    {
    }

    public PrismFightRemovedMessage(uint subAreaId)
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
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismFightRemovedMessage.subAreaId.");
    }
  }
}
