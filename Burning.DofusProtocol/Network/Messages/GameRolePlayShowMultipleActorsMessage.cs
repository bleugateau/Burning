using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayShowMultipleActorsMessage : NetworkMessage
  {
    public List<GameRolePlayActorInformations> informationsList = new List<GameRolePlayActorInformations>();
    public const uint Id = 6712;

    public override uint MessageId
    {
      get
      {
        return 6712;
      }
    }

    public GameRolePlayShowMultipleActorsMessage()
    {
    }

    public GameRolePlayShowMultipleActorsMessage(
      List<GameRolePlayActorInformations> informationsList)
    {
      this.informationsList = informationsList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.informationsList.Count);
      for (int index = 0; index < this.informationsList.Count; ++index)
      {
        writer.WriteShort((short) this.informationsList[index].TypeId);
        this.informationsList[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameRolePlayActorInformations instance = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.informationsList.Add(instance);
      }
    }
  }
}
