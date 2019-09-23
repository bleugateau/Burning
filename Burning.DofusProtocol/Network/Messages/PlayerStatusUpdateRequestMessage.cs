using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PlayerStatusUpdateRequestMessage : NetworkMessage
  {
    public const uint Id = 6387;
    public PlayerStatus status;

    public override uint MessageId
    {
      get
      {
        return 6387;
      }
    }

    public PlayerStatusUpdateRequestMessage()
    {
    }

    public PlayerStatusUpdateRequestMessage(PlayerStatus status)
    {
      this.status = status;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
    }
  }
}
