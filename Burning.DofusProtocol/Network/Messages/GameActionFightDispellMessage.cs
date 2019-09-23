using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightDispellMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5533;
    public double targetId;
    public bool verboseCast;

    public override uint MessageId
    {
      get
      {
        return 5533;
      }
    }

    public GameActionFightDispellMessage()
    {
    }

    public GameActionFightDispellMessage(
      uint actionId,
      double sourceId,
      double targetId,
      bool verboseCast)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.verboseCast = verboseCast;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      writer.WriteBoolean(this.verboseCast);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightDispellMessage.targetId.");
      this.verboseCast = reader.ReadBoolean();
    }
  }
}
