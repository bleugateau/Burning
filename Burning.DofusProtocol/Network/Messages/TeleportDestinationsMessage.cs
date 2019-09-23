using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportDestinationsMessage : NetworkMessage
  {
    public List<TeleportDestination> destinations = new List<TeleportDestination>();
    public const uint Id = 6829;
    public uint type;

    public override uint MessageId
    {
      get
      {
        return 6829;
      }
    }

    public TeleportDestinationsMessage()
    {
    }

    public TeleportDestinationsMessage(uint type, List<TeleportDestination> destinations)
    {
      this.type = type;
      this.destinations = destinations;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
      writer.WriteShort((short) this.destinations.Count);
      for (int index = 0; index < this.destinations.Count; ++index)
        this.destinations[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of TeleportDestinationsMessage.type.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        TeleportDestination teleportDestination = new TeleportDestination();
        teleportDestination.Deserialize(reader);
        this.destinations.Add(teleportDestination);
      }
    }
  }
}
