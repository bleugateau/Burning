using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorAttackedResultMessage : NetworkMessage
  {
    public const uint Id = 5635;
    public bool deadOrAlive;
    public TaxCollectorBasicInformations basicInfos;
    public BasicGuildInformations guild;

    public override uint MessageId
    {
      get
      {
        return 5635;
      }
    }

    public TaxCollectorAttackedResultMessage()
    {
    }

    public TaxCollectorAttackedResultMessage(
      bool deadOrAlive,
      TaxCollectorBasicInformations basicInfos,
      BasicGuildInformations guild)
    {
      this.deadOrAlive = deadOrAlive;
      this.basicInfos = basicInfos;
      this.guild = guild;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.deadOrAlive);
      this.basicInfos.Serialize(writer);
      this.guild.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.deadOrAlive = reader.ReadBoolean();
      this.basicInfos = new TaxCollectorBasicInformations();
      this.basicInfos.Deserialize(reader);
      this.guild = new BasicGuildInformations();
      this.guild.Deserialize(reader);
    }
  }
}
