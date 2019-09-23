using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountRenameRequestMessage : NetworkMessage
  {
    public const uint Id = 5987;
    public string name;
    public int mountId;

    public override uint MessageId
    {
      get
      {
        return 5987;
      }
    }

    public MountRenameRequestMessage()
    {
    }

    public MountRenameRequestMessage(string name, int mountId)
    {
      this.name = name;
      this.mountId = mountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
      writer.WriteVarInt(this.mountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.name = reader.ReadUTF();
      this.mountId = reader.ReadVarInt();
    }
  }
}
