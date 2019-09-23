using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CurrentMapMessage : NetworkMessage
  {
    public const uint Id = 220;
    public double mapId;
    public string mapKey;

    public override uint MessageId
    {
      get
      {
        return 220;
      }
    }

    public CurrentMapMessage()
    {
    }

    public CurrentMapMessage(double mapId, string mapKey)
    {
      this.mapId = mapId;
      this.mapKey = mapKey;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      writer.WriteUTF(this.mapKey);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of CurrentMapMessage.mapId.");
      this.mapKey = reader.ReadUTF();
    }
  }
}
