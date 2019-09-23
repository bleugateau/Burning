using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightChangeLookMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5532;
    public double targetId;
    public EntityLook entityLook;

    public override uint MessageId
    {
      get
      {
        return 5532;
      }
    }

    public GameActionFightChangeLookMessage()
    {
    }

    public GameActionFightChangeLookMessage(
      uint actionId,
      double sourceId,
      double targetId,
      EntityLook entityLook)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.entityLook = entityLook;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      this.entityLook.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightChangeLookMessage.targetId.");
      this.entityLook = new EntityLook();
      this.entityLook.Deserialize(reader);
    }
  }
}
