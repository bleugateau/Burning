using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
  {
    public new const uint Id = 5884;

    public override uint MessageId
    {
      get
      {
        return 5884;
      }
    }

    public HouseSellFromInsideRequestMessage()
    {
    }

    public HouseSellFromInsideRequestMessage(uint instanceId, double amount, bool forSale)
      : base(instanceId, amount, forSale)
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
