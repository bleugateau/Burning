using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightPlacementSwapPositionsCancelledMessage : NetworkMessage
  {
    public const uint Id = 6546;
    public uint requestId;
    public double cancellerId;

    public override uint MessageId
    {
      get
      {
        return 6546;
      }
    }

    public GameFightPlacementSwapPositionsCancelledMessage()
    {
    }

    public GameFightPlacementSwapPositionsCancelledMessage(uint requestId, double cancellerId)
    {
      this.requestId = requestId;
      this.cancellerId = cancellerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element requestId.");
      writer.WriteInt((int) this.requestId);
      if (this.cancellerId < -9.00719925474099E+15 || this.cancellerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.cancellerId + ") on element cancellerId.");
      writer.WriteDouble(this.cancellerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.requestId = (uint) reader.ReadInt();
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element of GameFightPlacementSwapPositionsCancelledMessage.requestId.");
      this.cancellerId = reader.ReadDouble();
      if (this.cancellerId < -9.00719925474099E+15 || this.cancellerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.cancellerId + ") on element of GameFightPlacementSwapPositionsCancelledMessage.cancellerId.");
    }
  }
}
