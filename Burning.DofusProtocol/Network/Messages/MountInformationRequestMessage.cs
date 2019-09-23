using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountInformationRequestMessage : NetworkMessage
  {
    public const uint Id = 5972;
    public double id;
    public double time;

    public override uint MessageId
    {
      get
      {
        return 5972;
      }
    }

    public MountInformationRequestMessage()
    {
    }

    public MountInformationRequestMessage(double id, double time)
    {
      this.id = id;
      this.time = time;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      if (this.time < -9.00719925474099E+15 || this.time > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.time + ") on element time.");
      writer.WriteDouble(this.time);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of MountInformationRequestMessage.id.");
      this.time = reader.ReadDouble();
      if (this.time < -9.00719925474099E+15 || this.time > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.time + ") on element of MountInformationRequestMessage.time.");
    }
  }
}
