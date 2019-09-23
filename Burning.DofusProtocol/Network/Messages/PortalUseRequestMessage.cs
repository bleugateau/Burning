using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PortalUseRequestMessage : NetworkMessage
  {
    public const uint Id = 6492;
    public uint portalId;

    public override uint MessageId
    {
      get
      {
        return 6492;
      }
    }

    public PortalUseRequestMessage()
    {
    }

    public PortalUseRequestMessage(uint portalId)
    {
      this.portalId = portalId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.portalId < 0U)
        throw new Exception("Forbidden value (" + (object) this.portalId + ") on element portalId.");
      writer.WriteVarInt((int) this.portalId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.portalId = reader.ReadVarUhInt();
      if (this.portalId < 0U)
        throw new Exception("Forbidden value (" + (object) this.portalId + ") on element of PortalUseRequestMessage.portalId.");
    }
  }
}
