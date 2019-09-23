using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InteractiveUsedMessage : NetworkMessage
  {
    public const uint Id = 5745;
    public double entityId;
    public uint elemId;
    public uint skillId;
    public uint duration;
    public bool canMove;

    public override uint MessageId
    {
      get
      {
        return 5745;
      }
    }

    public InteractiveUsedMessage()
    {
    }

    public InteractiveUsedMessage(
      double entityId,
      uint elemId,
      uint skillId,
      uint duration,
      bool canMove)
    {
      this.entityId = entityId;
      this.elemId = elemId;
      this.skillId = skillId;
      this.duration = duration;
      this.canMove = canMove;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.entityId < 0.0 || this.entityId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.entityId + ") on element entityId.");
      writer.WriteVarLong((long) this.entityId);
      if (this.elemId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elemId + ") on element elemId.");
      writer.WriteVarInt((int) this.elemId);
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarShort((short) this.skillId);
      if (this.duration < 0U)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element duration.");
      writer.WriteVarShort((short) this.duration);
      writer.WriteBoolean(this.canMove);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.entityId = (double) reader.ReadVarUhLong();
      if (this.entityId < 0.0 || this.entityId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.entityId + ") on element of InteractiveUsedMessage.entityId.");
      this.elemId = reader.ReadVarUhInt();
      if (this.elemId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elemId + ") on element of InteractiveUsedMessage.elemId.");
      this.skillId = (uint) reader.ReadVarUhShort();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of InteractiveUsedMessage.skillId.");
      this.duration = (uint) reader.ReadVarUhShort();
      if (this.duration < 0U)
        throw new Exception("Forbidden value (" + (object) this.duration + ") on element of InteractiveUsedMessage.duration.");
      this.canMove = reader.ReadBoolean();
    }
  }
}
