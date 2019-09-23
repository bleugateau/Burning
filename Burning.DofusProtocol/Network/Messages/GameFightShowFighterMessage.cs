using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightShowFighterMessage : NetworkMessage
  {
    public const uint Id = 5864;
    public GameFightFighterInformations informations;

    public override uint MessageId
    {
      get
      {
        return 5864;
      }
    }

    public GameFightShowFighterMessage()
    {
    }

    public GameFightShowFighterMessage(GameFightFighterInformations informations)
    {
      this.informations = informations;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.informations.TypeId);
      this.informations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.informations = ProtocolTypeManager.GetInstance<GameFightFighterInformations>((uint) reader.ReadUShort());
      this.informations.Deserialize(reader);
    }
  }
}
