using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightRefreshFighterMessage : NetworkMessage
  {
    public const uint Id = 6309;
    public GameContextActorInformations informations;

    public override uint MessageId
    {
      get
      {
        return 6309;
      }
    }

    public GameFightRefreshFighterMessage()
    {
    }

    public GameFightRefreshFighterMessage(GameContextActorInformations informations)
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
      this.informations = ProtocolTypeManager.GetInstance<GameContextActorInformations>((uint) reader.ReadUShort());
      this.informations.Deserialize(reader);
    }
  }
}
