using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SlaveNoLongerControledMessage : NetworkMessage
  {
    public const uint Id = 6807;
    public double masterId;
    public double slaveId;

    public override uint MessageId
    {
      get
      {
        return 6807;
      }
    }

    public SlaveNoLongerControledMessage()
    {
    }

    public SlaveNoLongerControledMessage(double masterId, double slaveId)
    {
      this.masterId = masterId;
      this.slaveId = slaveId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element masterId.");
      writer.WriteDouble(this.masterId);
      if (this.slaveId < -9.00719925474099E+15 || this.slaveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.slaveId + ") on element slaveId.");
      writer.WriteDouble(this.slaveId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.masterId = reader.ReadDouble();
      if (this.masterId < -9.00719925474099E+15 || this.masterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.masterId + ") on element of SlaveNoLongerControledMessage.masterId.");
      this.slaveId = reader.ReadDouble();
      if (this.slaveId < -9.00719925474099E+15 || this.slaveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.slaveId + ") on element of SlaveNoLongerControledMessage.slaveId.");
    }
  }
}
