using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PaddockPropertiesMessage : NetworkMessage
  {
    public const uint Id = 5824;
    public PaddockInstancesInformations properties;

    public override uint MessageId
    {
      get
      {
        return 5824;
      }
    }

    public PaddockPropertiesMessage()
    {
    }

    public PaddockPropertiesMessage(PaddockInstancesInformations properties)
    {
      this.properties = properties;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.properties.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.properties = new PaddockInstancesInformations();
      this.properties.Deserialize(reader);
    }
  }
}
