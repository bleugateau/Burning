using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InteractiveUseEndedMessage : NetworkMessage
  {
    public const uint Id = 6112;
    public uint elemId;
    public uint skillId;

    public override uint MessageId
    {
      get
      {
        return 6112;
      }
    }

    public InteractiveUseEndedMessage()
    {
    }

    public InteractiveUseEndedMessage(uint elemId, uint skillId)
    {
      this.elemId = elemId;
      this.skillId = skillId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.elemId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elemId + ") on element elemId.");
      writer.WriteVarInt((int) this.elemId);
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarShort((short) this.skillId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.elemId = reader.ReadVarUhInt();
      if (this.elemId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elemId + ") on element of InteractiveUseEndedMessage.elemId.");
      this.skillId = (uint) reader.ReadVarUhShort();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of InteractiveUseEndedMessage.skillId.");
    }
  }
}
