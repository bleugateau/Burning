using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseTypeMessage : NetworkMessage
  {
    public const uint Id = 5803;
    public uint type;
    public bool follow;

    public override uint MessageId
    {
      get
      {
        return 5803;
      }
    }

    public ExchangeBidHouseTypeMessage()
    {
    }

    public ExchangeBidHouseTypeMessage(uint type, bool follow)
    {
      this.type = type;
      this.follow = follow;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element type.");
      writer.WriteVarInt((int) this.type);
      writer.WriteBoolean(this.follow);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.type = reader.ReadVarUhInt();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of ExchangeBidHouseTypeMessage.type.");
      this.follow = reader.ReadBoolean();
    }
  }
}
