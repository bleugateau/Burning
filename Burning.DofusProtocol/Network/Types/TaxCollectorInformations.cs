using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorInformations
  {
    public List<TaxCollectorComplementaryInformations> complements = new List<TaxCollectorComplementaryInformations>();
    public const uint Id = 167;
    public double uniqueId;
    public uint firtNameId;
    public uint lastNameId;
    public AdditionalTaxCollectorInformations additionalInfos;
    public int worldX;
    public int worldY;
    public uint subAreaId;
    public uint state;
    public EntityLook look;

    public virtual uint TypeId
    {
      get
      {
        return 167;
      }
    }

    public TaxCollectorInformations()
    {
    }

    public TaxCollectorInformations(
      double uniqueId,
      uint firtNameId,
      uint lastNameId,
      AdditionalTaxCollectorInformations additionalInfos,
      int worldX,
      int worldY,
      uint subAreaId,
      uint state,
      EntityLook look,
      List<TaxCollectorComplementaryInformations> complements)
    {
      this.uniqueId = uniqueId;
      this.firtNameId = firtNameId;
      this.lastNameId = lastNameId;
      this.additionalInfos = additionalInfos;
      this.worldX = worldX;
      this.worldY = worldY;
      this.subAreaId = subAreaId;
      this.state = state;
      this.look = look;
      this.complements = complements;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.uniqueId < 0.0 || this.uniqueId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.uniqueId + ") on element uniqueId.");
      writer.WriteDouble(this.uniqueId);
      if (this.firtNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firtNameId + ") on element firtNameId.");
      writer.WriteVarShort((short) this.firtNameId);
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element lastNameId.");
      writer.WriteVarShort((short) this.lastNameId);
      this.additionalInfos.Serialize(writer);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteByte((byte) this.state);
      this.look.Serialize(writer);
      writer.WriteShort((short) this.complements.Count);
      for (int index = 0; index < this.complements.Count; ++index)
      {
        writer.WriteShort((short) this.complements[index].TypeId);
        this.complements[index].Serialize(writer);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.uniqueId = reader.ReadDouble();
      if (this.uniqueId < 0.0 || this.uniqueId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.uniqueId + ") on element of TaxCollectorInformations.uniqueId.");
      this.firtNameId = (uint) reader.ReadVarUhShort();
      if (this.firtNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firtNameId + ") on element of TaxCollectorInformations.firtNameId.");
      this.lastNameId = (uint) reader.ReadVarUhShort();
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element of TaxCollectorInformations.lastNameId.");
      this.additionalInfos = new AdditionalTaxCollectorInformations();
      this.additionalInfos.Deserialize(reader);
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of TaxCollectorInformations.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of TaxCollectorInformations.worldY.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of TaxCollectorInformations.subAreaId.");
      this.state = (uint) reader.ReadByte();
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element of TaxCollectorInformations.state.");
      this.look = new EntityLook();
      this.look.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        TaxCollectorComplementaryInformations instance = ProtocolTypeManager.GetInstance<TaxCollectorComplementaryInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.complements.Add(instance);
      }
    }
  }
}
