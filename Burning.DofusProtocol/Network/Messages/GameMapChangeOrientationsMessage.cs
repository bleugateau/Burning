using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameMapChangeOrientationsMessage : NetworkMessage
  {
    public List<ActorOrientation> orientations = new List<ActorOrientation>();
    public const uint Id = 6155;

    public override uint MessageId
    {
      get
      {
        return 6155;
      }
    }

    public GameMapChangeOrientationsMessage()
    {
    }

    public GameMapChangeOrientationsMessage(List<ActorOrientation> orientations)
    {
      this.orientations = orientations;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.orientations.Count);
      for (int index = 0; index < this.orientations.Count; ++index)
        this.orientations[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ActorOrientation actorOrientation = new ActorOrientation();
        actorOrientation.Deserialize(reader);
        this.orientations.Add(actorOrientation);
      }
    }
  }
}
