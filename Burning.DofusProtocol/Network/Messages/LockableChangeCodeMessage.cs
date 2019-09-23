using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LockableChangeCodeMessage : NetworkMessage
  {
    public const uint Id = 5666;
    public string code;

    public override uint MessageId
    {
      get
      {
        return 5666;
      }
    }

    public LockableChangeCodeMessage()
    {
    }

    public LockableChangeCodeMessage(string code)
    {
      this.code = code;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.code);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.code = reader.ReadUTF();
    }
  }
}
