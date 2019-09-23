using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EntitiesInformationMessage : NetworkMessage
  {
    public List<EntityInformation> entities = new List<EntityInformation>();
    public const uint Id = 6775;

    public override uint MessageId
    {
      get
      {
        return 6775;
      }
    }

    public EntitiesInformationMessage()
    {
    }

    public EntitiesInformationMessage(List<EntityInformation> entities)
    {
      this.entities = entities;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.entities.Count);
      for (int index = 0; index < this.entities.Count; ++index)
        this.entities[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        EntityInformation entityInformation = new EntityInformation();
        entityInformation.Deserialize(reader);
        this.entities.Add(entityInformation);
      }
    }
  }
}
