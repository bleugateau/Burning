using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildPaddockBoughtMessage : NetworkMessage
  {
    public const uint Id = 5952;
    public PaddockContentInformations paddockInfo;

    public override uint MessageId
    {
      get
      {
        return 5952;
      }
    }

    public GuildPaddockBoughtMessage()
    {
    }

    public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo)
    {
      this.paddockInfo = paddockInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.paddockInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.paddockInfo = new PaddockContentInformations();
      this.paddockInfo.Deserialize(reader);
    }
  }
}
