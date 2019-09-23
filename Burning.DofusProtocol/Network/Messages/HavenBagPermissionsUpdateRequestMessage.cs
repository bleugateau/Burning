using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HavenBagPermissionsUpdateRequestMessage : NetworkMessage
  {
    public const uint Id = 6714;
    public uint permissions;

    public override uint MessageId
    {
      get
      {
        return 6714;
      }
    }

    public HavenBagPermissionsUpdateRequestMessage()
    {
    }

    public HavenBagPermissionsUpdateRequestMessage(uint permissions)
    {
      this.permissions = permissions;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.permissions < 0U)
        throw new Exception("Forbidden value (" + (object) this.permissions + ") on element permissions.");
      writer.WriteInt((int) this.permissions);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.permissions = (uint) reader.ReadInt();
      if (this.permissions < 0U)
        throw new Exception("Forbidden value (" + (object) this.permissions + ") on element of HavenBagPermissionsUpdateRequestMessage.permissions.");
    }
  }
}
