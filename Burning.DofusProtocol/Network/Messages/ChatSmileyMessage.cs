using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatSmileyMessage : NetworkMessage
  {
    public const uint Id = 801;
    public double entityId;
    public uint smileyId;
    public uint accountId;

    public override uint MessageId
    {
      get
      {
        return 801;
      }
    }

    public ChatSmileyMessage()
    {
    }

    public ChatSmileyMessage(double entityId, uint smileyId, uint accountId)
    {
      this.entityId = entityId;
      this.smileyId = smileyId;
      this.accountId = accountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.entityId < -9.00719925474099E+15 || this.entityId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.entityId + ") on element entityId.");
      writer.WriteDouble(this.entityId);
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element smileyId.");
      writer.WriteVarShort((short) this.smileyId);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.entityId = reader.ReadDouble();
      if (this.entityId < -9.00719925474099E+15 || this.entityId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.entityId + ") on element of ChatSmileyMessage.entityId.");
      this.smileyId = (uint) reader.ReadVarUhShort();
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element of ChatSmileyMessage.smileyId.");
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of ChatSmileyMessage.accountId.");
    }
  }
}
