using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class QuestStepInfoMessage : NetworkMessage
  {
    public const uint Id = 5625;
    public QuestActiveInformations infos;

    public override uint MessageId
    {
      get
      {
        return 5625;
      }
    }

    public QuestStepInfoMessage()
    {
    }

    public QuestStepInfoMessage(QuestActiveInformations infos)
    {
      this.infos = infos;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.infos.TypeId);
      this.infos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.infos = ProtocolTypeManager.GetInstance<QuestActiveInformations>((uint) reader.ReadUShort());
      this.infos.Deserialize(reader);
    }
  }
}
