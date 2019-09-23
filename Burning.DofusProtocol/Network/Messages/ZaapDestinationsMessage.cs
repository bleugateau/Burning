using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ZaapDestinationsMessage : TeleportDestinationsMessage
  {
    public new const uint Id = 6830;
    public double spawnMapId;

    public override uint MessageId
    {
      get
      {
        return 6830;
      }
    }

    public ZaapDestinationsMessage()
    {
    }

    public ZaapDestinationsMessage(
      uint type,
      List<TeleportDestination> destinations,
      double spawnMapId)
      : base(type, destinations)
    {
      this.spawnMapId = spawnMapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.spawnMapId < 0.0 || this.spawnMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.spawnMapId + ") on element spawnMapId.");
      writer.WriteDouble(this.spawnMapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.spawnMapId = reader.ReadDouble();
      if (this.spawnMapId < 0.0 || this.spawnMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.spawnMapId + ") on element of ZaapDestinationsMessage.spawnMapId.");
    }
  }
}
