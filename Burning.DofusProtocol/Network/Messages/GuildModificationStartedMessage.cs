using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildModificationStartedMessage : NetworkMessage
  {
    public const uint Id = 6324;
    public bool canChangeName;
    public bool canChangeEmblem;

    public override uint MessageId
    {
      get
      {
        return 6324;
      }
    }

    public GuildModificationStartedMessage()
    {
    }

    public GuildModificationStartedMessage(bool canChangeName, bool canChangeEmblem)
    {
      this.canChangeName = canChangeName;
      this.canChangeEmblem = canChangeEmblem;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.canChangeName), (byte) 1, this.canChangeEmblem);
      writer.WriteByte((byte) num);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.canChangeName = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.canChangeEmblem = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
    }
  }
}
