using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorBasicInformations
  {
    public const uint Id = 96;
    public uint firstNameId;
    public uint lastNameId;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;

    public virtual uint TypeId
    {
      get
      {
        return 96;
      }
    }

    public TaxCollectorBasicInformations()
    {
    }

    public TaxCollectorBasicInformations(
      uint firstNameId,
      uint lastNameId,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId)
    {
      this.firstNameId = firstNameId;
      this.lastNameId = lastNameId;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element firstNameId.");
      writer.WriteVarShort((short) this.firstNameId);
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element lastNameId.");
      writer.WriteVarShort((short) this.lastNameId);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.firstNameId = (uint) reader.ReadVarUhShort();
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element of TaxCollectorBasicInformations.firstNameId.");
      this.lastNameId = (uint) reader.ReadVarUhShort();
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element of TaxCollectorBasicInformations.lastNameId.");
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of TaxCollectorBasicInformations.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of TaxCollectorBasicInformations.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of TaxCollectorBasicInformations.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of TaxCollectorBasicInformations.subAreaId.");
    }
  }
}
