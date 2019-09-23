using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SymbioticObjectAssociatedMessage : NetworkMessage
  {
    public const uint Id = 6527;
    public uint hostUID;

    public override uint MessageId
    {
      get
      {
        return 6527;
      }
    }

    public SymbioticObjectAssociatedMessage()
    {
    }

    public SymbioticObjectAssociatedMessage(uint hostUID)
    {
      this.hostUID = hostUID;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.hostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.hostUID + ") on element hostUID.");
      writer.WriteVarInt((int) this.hostUID);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.hostUID = reader.ReadVarUhInt();
      if (this.hostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.hostUID + ") on element of SymbioticObjectAssociatedMessage.hostUID.");
    }
  }
}
