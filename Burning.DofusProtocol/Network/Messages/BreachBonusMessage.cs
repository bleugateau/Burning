using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachBonusMessage : NetworkMessage
  {
    public const uint Id = 6800;
    public ObjectEffectInteger bonus;

    public override uint MessageId
    {
      get
      {
        return 6800;
      }
    }

    public BreachBonusMessage()
    {
    }

    public BreachBonusMessage(ObjectEffectInteger bonus)
    {
      this.bonus = bonus;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.bonus.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.bonus = new ObjectEffectInteger();
      this.bonus.Deserialize(reader);
    }
  }
}
