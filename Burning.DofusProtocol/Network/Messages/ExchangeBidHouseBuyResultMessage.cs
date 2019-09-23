using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseBuyResultMessage : NetworkMessage
  {
    public const uint Id = 6272;
    public uint uid;
    public bool bought;

    public override uint MessageId
    {
      get
      {
        return 6272;
      }
    }

    public ExchangeBidHouseBuyResultMessage()
    {
    }

    public ExchangeBidHouseBuyResultMessage(uint uid, bool bought)
    {
      this.uid = uid;
      this.bought = bought;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element uid.");
      writer.WriteVarInt((int) this.uid);
      writer.WriteBoolean(this.bought);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.uid = reader.ReadVarUhInt();
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element of ExchangeBidHouseBuyResultMessage.uid.");
      this.bought = reader.ReadBoolean();
    }
  }
}
