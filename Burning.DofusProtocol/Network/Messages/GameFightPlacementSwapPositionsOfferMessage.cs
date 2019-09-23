using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightPlacementSwapPositionsOfferMessage : NetworkMessage
  {
    public const uint Id = 6542;
    public uint requestId;
    public double requesterId;
    public uint requesterCellId;
    public double requestedId;
    public uint requestedCellId;

    public override uint MessageId
    {
      get
      {
        return 6542;
      }
    }

    public GameFightPlacementSwapPositionsOfferMessage()
    {
    }

    public GameFightPlacementSwapPositionsOfferMessage(
      uint requestId,
      double requesterId,
      uint requesterCellId,
      double requestedId,
      uint requestedCellId)
    {
      this.requestId = requestId;
      this.requesterId = requesterId;
      this.requesterCellId = requesterCellId;
      this.requestedId = requestedId;
      this.requestedCellId = requestedCellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element requestId.");
      writer.WriteInt((int) this.requestId);
      if (this.requesterId < -9.00719925474099E+15 || this.requesterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.requesterId + ") on element requesterId.");
      writer.WriteDouble(this.requesterId);
      if (this.requesterCellId < 0U || this.requesterCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.requesterCellId + ") on element requesterCellId.");
      writer.WriteVarShort((short) this.requesterCellId);
      if (this.requestedId < -9.00719925474099E+15 || this.requestedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.requestedId + ") on element requestedId.");
      writer.WriteDouble(this.requestedId);
      if (this.requestedCellId < 0U || this.requestedCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.requestedCellId + ") on element requestedCellId.");
      writer.WriteVarShort((short) this.requestedCellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.requestId = (uint) reader.ReadInt();
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requestId.");
      this.requesterId = reader.ReadDouble();
      if (this.requesterId < -9.00719925474099E+15 || this.requesterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.requesterId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requesterId.");
      this.requesterCellId = (uint) reader.ReadVarUhShort();
      if (this.requesterCellId < 0U || this.requesterCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.requesterCellId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requesterCellId.");
      this.requestedId = reader.ReadDouble();
      if (this.requestedId < -9.00719925474099E+15 || this.requestedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.requestedId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requestedId.");
      this.requestedCellId = (uint) reader.ReadVarUhShort();
      if (this.requestedCellId < 0U || this.requestedCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.requestedCellId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requestedCellId.");
    }
  }
}
