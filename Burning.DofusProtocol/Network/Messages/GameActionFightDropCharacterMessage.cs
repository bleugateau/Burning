using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightDropCharacterMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5826;
    public double targetId;
    public int cellId;

    public override uint MessageId
    {
      get
      {
        return 5826;
      }
    }

    public GameActionFightDropCharacterMessage()
    {
    }

    public GameActionFightDropCharacterMessage(
      uint actionId,
      double sourceId,
      double targetId,
      int cellId)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.cellId = cellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.cellId < -1 || this.cellId > 559)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteShort((short) this.cellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightDropCharacterMessage.targetId.");
      this.cellId = (int) reader.ReadShort();
      if (this.cellId < -1 || this.cellId > 559)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of GameActionFightDropCharacterMessage.cellId.");
    }
  }
}
