using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TeleportDestination
  {
    public const uint Id = 563;
    public uint type;
    public double mapId;
    public uint subAreaId;
    public uint level;
    public uint cost;

    public virtual uint TypeId
    {
      get
      {
        return 563;
      }
    }

    public TeleportDestination()
    {
    }

    public TeleportDestination(uint type, double mapId, uint subAreaId, uint level, uint cost)
    {
      this.type = type;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.level = level;
      this.cost = cost;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      if (this.cost < 0U)
        throw new Exception("Forbidden value (" + (object) this.cost + ") on element cost.");
      writer.WriteVarShort((short) this.cost);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of TeleportDestination.type.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of TeleportDestination.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of TeleportDestination.subAreaId.");
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of TeleportDestination.level.");
      this.cost = (uint) reader.ReadVarUhShort();
      if (this.cost < 0U)
        throw new Exception("Forbidden value (" + (object) this.cost + ") on element of TeleportDestination.cost.");
    }
  }
}
