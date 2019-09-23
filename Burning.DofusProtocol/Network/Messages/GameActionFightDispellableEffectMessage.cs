using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
  {
    public new const uint Id = 6070;
    public AbstractFightDispellableEffect effect;

    public override uint MessageId
    {
      get
      {
        return 6070;
      }
    }

    public GameActionFightDispellableEffectMessage()
    {
    }

    public GameActionFightDispellableEffectMessage(
      uint actionId,
      double sourceId,
      AbstractFightDispellableEffect effect)
      : base(actionId, sourceId)
    {
      this.effect = effect;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.effect.TypeId);
      this.effect.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>((uint) reader.ReadUShort());
      this.effect.Deserialize(reader);
    }
  }
}
