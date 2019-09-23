using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapFightStartPositionsUpdateMessage : NetworkMessage
  {
    public const uint Id = 6716;
    public double mapId;
    public FightStartingPositions fightStartPositions;

    public override uint MessageId
    {
      get
      {
        return 6716;
      }
    }

    public MapFightStartPositionsUpdateMessage()
    {
    }

    public MapFightStartPositionsUpdateMessage(
      double mapId,
      FightStartingPositions fightStartPositions)
    {
      this.mapId = mapId;
      this.fightStartPositions = fightStartPositions;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      this.fightStartPositions.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of MapFightStartPositionsUpdateMessage.mapId.");
      this.fightStartPositions = new FightStartingPositions();
      this.fightStartPositions.Deserialize(reader);
    }
  }
}
