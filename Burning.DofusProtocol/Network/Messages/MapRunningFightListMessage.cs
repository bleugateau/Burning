using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapRunningFightListMessage : NetworkMessage
  {
    public List<FightExternalInformations> fights = new List<FightExternalInformations>();
    public const uint Id = 5743;

    public override uint MessageId
    {
      get
      {
        return 5743;
      }
    }

    public MapRunningFightListMessage()
    {
    }

    public MapRunningFightListMessage(List<FightExternalInformations> fights)
    {
      this.fights = fights;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.fights.Count);
      for (int index = 0; index < this.fights.Count; ++index)
        this.fights[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        FightExternalInformations externalInformations = new FightExternalInformations();
        externalInformations.Deserialize(reader);
        this.fights.Add(externalInformations);
      }
    }
  }
}
