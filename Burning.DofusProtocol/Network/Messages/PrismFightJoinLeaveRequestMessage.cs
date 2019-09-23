using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightJoinLeaveRequestMessage : NetworkMessage
  {
    public const uint Id = 5843;
    public uint subAreaId;
    public bool join;

    public override uint MessageId
    {
      get
      {
        return 5843;
      }
    }

    public PrismFightJoinLeaveRequestMessage()
    {
    }

    public PrismFightJoinLeaveRequestMessage(uint subAreaId, bool join)
    {
      this.subAreaId = subAreaId;
      this.join = join;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteBoolean(this.join);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismFightJoinLeaveRequestMessage.subAreaId.");
      this.join = reader.ReadBoolean();
    }
  }
}
