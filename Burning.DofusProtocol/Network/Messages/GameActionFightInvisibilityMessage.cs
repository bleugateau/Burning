using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5821;
    public double targetId;
    public uint state;

    public override uint MessageId
    {
      get
      {
        return 5821;
      }
    }

    public GameActionFightInvisibilityMessage()
    {
    }

    public GameActionFightInvisibilityMessage(
      uint actionId,
      double sourceId,
      double targetId,
      uint state)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.state = state;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      writer.WriteByte((byte) this.state);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightInvisibilityMessage.targetId.");
      this.state = (uint) reader.ReadByte();
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element of GameActionFightInvisibilityMessage.state.");
    }
  }
}
