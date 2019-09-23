using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectModifyPricedMessage : ExchangeObjectMovePricedMessage
  {
    public new const uint Id = 6238;

    public override uint MessageId
    {
      get
      {
        return 6238;
      }
    }

    public ExchangeObjectModifyPricedMessage()
    {
    }

    public ExchangeObjectModifyPricedMessage(uint objectUID, int quantity, double price)
      : base(objectUID, quantity, price)
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
