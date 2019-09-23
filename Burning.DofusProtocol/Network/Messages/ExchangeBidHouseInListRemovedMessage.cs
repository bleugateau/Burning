using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
  {
    public const uint Id = 5950;
    public int itemUID;

    public override uint MessageId
    {
      get
      {
        return 5950;
      }
    }

    public ExchangeBidHouseInListRemovedMessage()
    {
    }

    public ExchangeBidHouseInListRemovedMessage(int itemUID)
    {
      this.itemUID = itemUID;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.itemUID);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.itemUID = reader.ReadInt();
    }
  }
}
