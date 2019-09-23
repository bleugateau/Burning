using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseListMessage : NetworkMessage
  {
    public const uint Id = 5807;
    public uint id;
    public bool follow;

    public override uint MessageId
    {
      get
      {
        return 5807;
      }
    }

    public ExchangeBidHouseListMessage()
    {
    }

    public ExchangeBidHouseListMessage(uint id, bool follow)
    {
      this.id = id;
      this.follow = follow;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      writer.WriteBoolean(this.follow);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of ExchangeBidHouseListMessage.id.");
      this.follow = reader.ReadBoolean();
    }
  }
}
