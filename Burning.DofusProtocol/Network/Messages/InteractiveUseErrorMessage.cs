using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InteractiveUseErrorMessage : NetworkMessage
  {
    public const uint Id = 6384;
    public uint elemId;
    public uint skillInstanceUid;

    public override uint MessageId
    {
      get
      {
        return 6384;
      }
    }

    public InteractiveUseErrorMessage()
    {
    }

    public InteractiveUseErrorMessage(uint elemId, uint skillInstanceUid)
    {
      this.elemId = elemId;
      this.skillInstanceUid = skillInstanceUid;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.elemId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elemId + ") on element elemId.");
      writer.WriteVarInt((int) this.elemId);
      if (this.skillInstanceUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillInstanceUid + ") on element skillInstanceUid.");
      writer.WriteVarInt((int) this.skillInstanceUid);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.elemId = reader.ReadVarUhInt();
      if (this.elemId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elemId + ") on element of InteractiveUseErrorMessage.elemId.");
      this.skillInstanceUid = reader.ReadVarUhInt();
      if (this.skillInstanceUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillInstanceUid + ") on element of InteractiveUseErrorMessage.skillInstanceUid.");
    }
  }
}
