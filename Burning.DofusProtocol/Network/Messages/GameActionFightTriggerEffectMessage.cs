using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage
  {
    public new const uint Id = 6147;

    public override uint MessageId
    {
      get
      {
        return 6147;
      }
    }

    public GameActionFightTriggerEffectMessage()
    {
    }

    public GameActionFightTriggerEffectMessage(
      uint actionId,
      double sourceId,
      double targetId,
      bool verboseCast,
      uint boostUID)
      : base(actionId, sourceId, targetId, verboseCast, boostUID)
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
