using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
  {
    public new const uint Id = 6113;
    public uint boostUID;

    public override uint MessageId
    {
      get
      {
        return 6113;
      }
    }

    public GameActionFightDispellEffectMessage()
    {
    }

    public GameActionFightDispellEffectMessage(
      uint actionId,
      double sourceId,
      double targetId,
      bool verboseCast,
      uint boostUID)
      : base(actionId, sourceId, targetId, verboseCast)
    {
      this.boostUID = boostUID;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.boostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostUID + ") on element boostUID.");
      writer.WriteInt((int) this.boostUID);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.boostUID = (uint) reader.ReadInt();
      if (this.boostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostUID + ") on element of GameActionFightDispellEffectMessage.boostUID.");
    }
  }
}
