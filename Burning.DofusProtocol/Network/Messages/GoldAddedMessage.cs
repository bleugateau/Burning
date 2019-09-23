using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GoldAddedMessage : NetworkMessage
  {
    public const uint Id = 6030;
    public GoldItem gold;

    public override uint MessageId
    {
      get
      {
        return 6030;
      }
    }

    public GoldAddedMessage()
    {
    }

    public GoldAddedMessage(GoldItem gold)
    {
      this.gold = gold;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.gold.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.gold = new GoldItem();
      this.gold.Deserialize(reader);
    }
  }
}
