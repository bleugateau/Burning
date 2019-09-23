using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LockableUseCodeMessage : NetworkMessage
  {
    public const uint Id = 5667;
    public string code;

    public override uint MessageId
    {
      get
      {
        return 5667;
      }
    }

    public LockableUseCodeMessage()
    {
    }

    public LockableUseCodeMessage(string code)
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
