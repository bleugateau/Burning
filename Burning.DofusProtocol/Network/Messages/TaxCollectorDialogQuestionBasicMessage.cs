using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
  {
    public const uint Id = 5619;
    public BasicGuildInformations guildInfo;

    public override uint MessageId
    {
      get
      {
        return 5619;
      }
    }

    public TaxCollectorDialogQuestionBasicMessage()
    {
    }

    public TaxCollectorDialogQuestionBasicMessage(BasicGuildInformations guildInfo)
    {
      this.guildInfo = guildInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.guildInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildInfo = new BasicGuildInformations();
      this.guildInfo.Deserialize(reader);
    }
  }
}
