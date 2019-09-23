using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightSynchronizeMessage : NetworkMessage
  {
    public List<GameFightFighterInformations> fighters = new List<GameFightFighterInformations>();
    public const uint Id = 5921;

    public override uint MessageId
    {
      get
      {
        return 5921;
      }
    }

    public GameFightSynchronizeMessage()
    {
    }

    public GameFightSynchronizeMessage(List<GameFightFighterInformations> fighters)
    {
      this.fighters = fighters;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.fighters.Count);
      for (int index = 0; index < this.fighters.Count; ++index)
      {
        writer.WriteShort((short) this.fighters[index].TypeId);
        this.fighters[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameFightFighterInformations instance = ProtocolTypeManager.GetInstance<GameFightFighterInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.fighters.Add(instance);
      }
    }
  }
}
