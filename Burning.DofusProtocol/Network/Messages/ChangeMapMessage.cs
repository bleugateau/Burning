using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChangeMapMessage : NetworkMessage
  {
    public const uint Id = 221;
    public double mapId;
    public bool autopilot;

    public override uint MessageId
    {
      get
      {
        return 221;
      }
    }

    public ChangeMapMessage()
    {
    }

    public ChangeMapMessage(double mapId, bool autopilot)
    {
      this.mapId = mapId;
      this.autopilot = autopilot;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      writer.WriteBoolean(this.autopilot);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of ChangeMapMessage.mapId.");
      this.autopilot = reader.ReadBoolean();
    }
  }
}
