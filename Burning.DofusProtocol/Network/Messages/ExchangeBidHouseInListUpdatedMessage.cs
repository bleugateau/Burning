using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
  {
    public new const uint Id = 6337;

    public override uint MessageId
    {
      get
      {
        return 6337;
      }
    }

    public ExchangeBidHouseInListUpdatedMessage()
    {
    }

    public ExchangeBidHouseInListUpdatedMessage(
      int itemUID,
      int objGenericId,
      List<ObjectEffect> effects,
      List<double> prices)
      : base(itemUID, objGenericId, effects, prices)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
