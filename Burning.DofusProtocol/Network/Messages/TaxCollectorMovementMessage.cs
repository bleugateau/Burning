using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorMovementMessage : NetworkMessage
  {
    public const uint Id = 5633;
    public uint movementType;
    public TaxCollectorBasicInformations basicInfos;
    public double playerId;
    public string playerName;

    public override uint MessageId
    {
      get
      {
        return 5633;
      }
    }

    public TaxCollectorMovementMessage()
    {
    }

    public TaxCollectorMovementMessage(
      uint movementType,
      TaxCollectorBasicInformations basicInfos,
      double playerId,
      string playerName)
    {
      this.movementType = movementType;
      this.basicInfos = basicInfos;
      this.playerId = playerId;
      this.playerName = playerName;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.movementType);
      this.basicInfos.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.movementType = (uint) reader.ReadByte();
      if (this.movementType < 0U)
        throw new Exception("Forbidden value (" + (object) this.movementType + ") on element of TaxCollectorMovementMessage.movementType.");
      this.basicInfos = new TaxCollectorBasicInformations();
      this.basicInfos.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of TaxCollectorMovementMessage.playerId.");
      this.playerName = reader.ReadUTF();
    }
  }
}
