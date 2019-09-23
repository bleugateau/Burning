using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightAddedMessage : NetworkMessage
  {
    public const uint Id = 6452;
    public PrismFightersInformation fight;

    public override uint MessageId
    {
      get
      {
        return 6452;
      }
    }

    public PrismFightAddedMessage()
    {
    }

    public PrismFightAddedMessage(PrismFightersInformation fight)
    {
      this.fight = fight;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.fight.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fight = new PrismFightersInformation();
      this.fight.Deserialize(reader);
    }
  }
}
