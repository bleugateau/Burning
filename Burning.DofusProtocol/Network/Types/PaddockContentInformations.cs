using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PaddockContentInformations : PaddockInformations
  {
    public List<MountInformationsForPaddock> mountsInformations = new List<MountInformationsForPaddock>();
    public new const uint Id = 183;
    public double paddockId;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;
    public bool abandonned;

    public override uint TypeId
    {
      get
      {
        return 183;
      }
    }

    public PaddockContentInformations()
    {
    }

    public PaddockContentInformations(
      uint maxOutdoorMount,
      uint maxItems,
      double paddockId,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId,
      bool abandonned,
      List<MountInformationsForPaddock> mountsInformations)
      : base(maxOutdoorMount, maxItems)
    {
      this.paddockId = paddockId;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.abandonned = abandonned;
      this.mountsInformations = mountsInformations;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.paddockId < 0.0 || this.paddockId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.paddockId + ") on element paddockId.");
      writer.WriteDouble(this.paddockId);
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
      writer.WriteBoolean(this.abandonned);
      writer.WriteShort((short) this.mountsInformations.Count);
      for (int index = 0; index < this.mountsInformations.Count; ++index)
        this.mountsInformations[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.paddockId = reader.ReadDouble();
      if (this.paddockId < 0.0 || this.paddockId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.paddockId + ") on element of PaddockContentInformations.paddockId.");
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of PaddockContentInformations.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of PaddockContentInformations.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of PaddockContentInformations.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PaddockContentInformations.subAreaId.");
      this.abandonned = reader.ReadBoolean();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MountInformationsForPaddock informationsForPaddock = new MountInformationsForPaddock();
        informationsForPaddock.Deserialize(reader);
        this.mountsInformations.Add(informationsForPaddock);
      }
    }
  }
}
