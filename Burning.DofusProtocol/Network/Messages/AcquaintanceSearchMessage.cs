using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AcquaintanceSearchMessage : NetworkMessage
  {
    public const uint Id = 6144;
    public string nickname;

    public override uint MessageId
    {
      get
      {
        return 6144;
      }
    }

    public AcquaintanceSearchMessage()
    {
    }

    public AcquaintanceSearchMessage(string nickname)
    {
      this.nickname = nickname;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.nickname);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.nickname = reader.ReadUTF();
    }
  }
}
