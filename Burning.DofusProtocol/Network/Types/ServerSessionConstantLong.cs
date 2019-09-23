using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ServerSessionConstantLong : ServerSessionConstant
  {
    public new const uint Id = 429;
    public double value;

    public override uint TypeId
    {
      get
      {
        return 429;
      }
    }

    public ServerSessionConstantLong()
    {
    }

    public ServerSessionConstantLong(uint id, double value)
      : base(id)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.value < -9.00719925474099E+15 || this.value > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.value + ") on element value.");
      writer.WriteDouble(this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = reader.ReadDouble();
      if (this.value < -9.00719925474099E+15 || this.value > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.value + ") on element of ServerSessionConstantLong.value.");
    }
  }
}
