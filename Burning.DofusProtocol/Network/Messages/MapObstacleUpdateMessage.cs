using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapObstacleUpdateMessage : NetworkMessage
  {
    public List<MapObstacle> obstacles = new List<MapObstacle>();
    public const uint Id = 6051;

    public override uint MessageId
    {
      get
      {
        return 6051;
      }
    }

    public MapObstacleUpdateMessage()
    {
    }

    public MapObstacleUpdateMessage(List<MapObstacle> obstacles)
    {
      this.obstacles = obstacles;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.obstacles.Count);
      for (int index = 0; index < this.obstacles.Count; ++index)
        this.obstacles[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MapObstacle mapObstacle = new MapObstacle();
        mapObstacle.Deserialize(reader);
        this.obstacles.Add(mapObstacle);
      }
    }
  }
}
