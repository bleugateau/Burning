using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IgnoredDeleteResultMessage : NetworkMessage
  {
    public const uint Id = 5677;
    public bool success;
    public string name;
    public bool session;

    public override uint MessageId
    {
      get
      {
        return 5677;
      }
    }

    public IgnoredDeleteResultMessage()
    {
    }

    public IgnoredDeleteResultMessage(bool success, string name, bool session)
    {
      this.success = success;
      this.name = name;
      this.session = session;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.success), (byte) 1, this.session);
      writer.WriteByte((byte) num);
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.success = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.session = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.name = reader.ReadUTF();
    }
  }
}
