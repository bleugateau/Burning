using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CompassUpdateMessage : NetworkMessage
  {
    public const uint Id = 5591;
    public uint type;
    public MapCoordinates coords;

    public override uint MessageId
    {
      get
      {
        return 5591;
      }
    }

    public CompassUpdateMessage()
    {
    }

    public CompassUpdateMessage(uint type, MapCoordinates coords)
    {
      this.type = type;
      this.coords = coords;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
      writer.WriteShort((short) this.coords.TypeId);
      this.coords.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of CompassUpdateMessage.type.");
      this.coords = ProtocolTypeManager.GetInstance<MapCoordinates>((uint) reader.ReadUShort());
      this.coords.Deserialize(reader);
    }
  }
}
