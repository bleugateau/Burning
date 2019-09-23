using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftInformationObjectMessage : ExchangeCraftResultWithObjectIdMessage
  {
    public new const uint Id = 5794;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 5794;
      }
    }

    public ExchangeCraftInformationObjectMessage()
    {
    }

    public ExchangeCraftInformationObjectMessage(
      uint craftResult,
      uint objectGenericId,
      double playerId)
      : base(craftResult, objectGenericId)
    {
      this.playerId = playerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of ExchangeCraftInformationObjectMessage.playerId.");
    }
  }
}
