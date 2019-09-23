using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayShowActorMessage : NetworkMessage
  {
    public const uint Id = 5632;
    public GameRolePlayActorInformations informations;

    public override uint MessageId
    {
      get
      {
        return 5632;
      }
    }

    public GameRolePlayShowActorMessage()
    {
    }

    public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
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
      this.informations = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>((uint) reader.ReadUShort());
      this.informations.Deserialize(reader);
    }
  }
}
