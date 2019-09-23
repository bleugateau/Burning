using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EntityInformationMessage : NetworkMessage
  {
    public const uint Id = 6771;
    public EntityInformation entity;

    public override uint MessageId
    {
      get
      {
        return 6771;
      }
    }

    public EntityInformationMessage()
    {
    }

    public EntityInformationMessage(EntityInformation entity)
    {
      this.entity = entity;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.entity.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.entity = new EntityInformation();
      this.entity.Deserialize(reader);
    }
  }
}
