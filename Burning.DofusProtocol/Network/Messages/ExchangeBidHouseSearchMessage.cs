using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseSearchMessage : NetworkMessage
  {
    public const uint Id = 5806;
    public uint genId;
    public bool follow;

    public override uint MessageId
    {
      get
      {
        return 5806;
      }
    }

    public ExchangeBidHouseSearchMessage()
    {
    }

    public ExchangeBidHouseSearchMessage(uint genId, bool follow)
    {
      this.genId = genId;
      this.follow = follow;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.genId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genId + ") on element genId.");
      writer.WriteVarShort((short) this.genId);
      writer.WriteBoolean(this.follow);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.genId = (uint) reader.ReadVarUhShort();
      if (this.genId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genId + ") on element of ExchangeBidHouseSearchMessage.genId.");
      this.follow = reader.ReadBoolean();
    }
  }
}
