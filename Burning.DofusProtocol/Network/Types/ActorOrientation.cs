using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ActorOrientation
  {
    public const uint Id = 353;
    public double id;
    public uint direction;

    public virtual uint TypeId
    {
      get
      {
        return 353;
      }
    }

    public ActorOrientation()
    {
    }

    public ActorOrientation(double id, uint direction)
    {
      this.id = id;
      this.direction = direction;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      writer.WriteByte((byte) this.direction);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of ActorOrientation.id.");
      this.direction = (uint) reader.ReadByte();
      if (this.direction < 0U)
        throw new Exception("Forbidden value (" + (object) this.direction + ") on element of ActorOrientation.direction.");
    }
  }
}
