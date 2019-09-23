using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeShopStockMovementUpdatedMessage : NetworkMessage
  {
    public const uint Id = 5909;
    public ObjectItemToSell objectInfo;

    public override uint MessageId
    {
      get
      {
        return 5909;
      }
    }

    public ExchangeShopStockMovementUpdatedMessage()
    {
    }

    public ExchangeShopStockMovementUpdatedMessage(ObjectItemToSell objectInfo)
    {
      this.objectInfo = objectInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.objectInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectInfo = new ObjectItemToSell();
      this.objectInfo.Deserialize(reader);
    }
  }
}
