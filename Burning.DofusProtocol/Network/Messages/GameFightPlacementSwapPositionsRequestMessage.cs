using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightPlacementSwapPositionsRequestMessage : GameFightPlacementPositionRequestMessage
  {
    public new const uint Id = 6541;
    public double requestedId;

    public override uint MessageId
    {
      get
      {
        return 6541;
      }
    }

    public GameFightPlacementSwapPositionsRequestMessage()
    {
    }

    public GameFightPlacementSwapPositionsRequestMessage(uint cellId, double requestedId)
      : base(cellId)
    {
      this.requestedId = requestedId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.requestedId < -9.00719925474099E+15 || this.requestedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.requestedId + ") on element requestedId.");
      writer.WriteDouble(this.requestedId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.requestedId = reader.ReadDouble();
      if (this.requestedId < -9.00719925474099E+15 || this.requestedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.requestedId + ") on element of GameFightPlacementSwapPositionsRequestMessage.requestedId.");
    }
  }
}
