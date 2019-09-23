using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorMovement
  {
    public const uint Id = 493;
    public uint movementType;
    public TaxCollectorBasicInformations basicInfos;
    public double playerId;
    public string playerName;

    public virtual uint TypeId
    {
      get
      {
        return 493;
      }
    }

    public TaxCollectorMovement()
    {
    }

    public TaxCollectorMovement(
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

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.movementType);
      this.basicInfos.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.movementType = (uint) reader.ReadByte();
      if (this.movementType < 0U)
        throw new Exception("Forbidden value (" + (object) this.movementType + ") on element of TaxCollectorMovement.movementType.");
      this.basicInfos = new TaxCollectorBasicInformations();
      this.basicInfos.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of TaxCollectorMovement.playerId.");
      this.playerName = reader.ReadUTF();
    }
  }
}
