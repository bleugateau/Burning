using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AccessoryPreviewMessage : NetworkMessage
  {
    public const uint Id = 6517;
    public EntityLook look;

    public override uint MessageId
    {
      get
      {
        return 6517;
      }
    }

    public AccessoryPreviewMessage()
    {
    }

    public AccessoryPreviewMessage(EntityLook look)
    {
      this.look = look;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.look = new EntityLook();
      this.look.Deserialize(reader);
    }
  }
}
