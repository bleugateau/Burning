using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountInformationInPaddockRequestMessage : NetworkMessage
  {
    public const uint Id = 5975;
    public int mapRideId;

    public override uint MessageId
    {
      get
      {
        return 5975;
      }
    }

    public MountInformationInPaddockRequestMessage()
    {
    }

    public MountInformationInPaddockRequestMessage(int mapRideId)
    {
      this.mapRideId = mapRideId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteVarInt(this.mapRideId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapRideId = reader.ReadVarInt();
    }
  }
}
