using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ZaapRespawnUpdatedMessage : NetworkMessage
  {
    public const uint Id = 6571;
    public double mapId;

    public override uint MessageId
    {
      get
      {
        return 6571;
      }
    }

    public ZaapRespawnUpdatedMessage()
    {
    }

    public ZaapRespawnUpdatedMessage(double mapId)
    {
      this.mapId = mapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of ZaapRespawnUpdatedMessage.mapId.");
    }
  }
}
