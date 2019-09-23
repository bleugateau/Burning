using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TreasureHuntFlag
  {
    public const uint Id = 473;
    public double mapId;
    public uint state;

    public virtual uint TypeId
    {
      get
      {
        return 473;
      }
    }

    public TreasureHuntFlag()
    {
    }

    public TreasureHuntFlag(double mapId, uint state)
    {
      this.mapId = mapId;
      this.state = state;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      writer.WriteByte((byte) this.state);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of TreasureHuntFlag.mapId.");
      this.state = (uint) reader.ReadByte();
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element of TreasureHuntFlag.state.");
    }
  }
}
