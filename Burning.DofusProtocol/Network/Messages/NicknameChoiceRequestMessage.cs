using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NicknameChoiceRequestMessage : NetworkMessage
  {
    public const uint Id = 5639;
    public string nickname;

    public override uint MessageId
    {
      get
      {
        return 5639;
      }
    }

    public NicknameChoiceRequestMessage()
    {
    }

    public NicknameChoiceRequestMessage(string nickname)
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
