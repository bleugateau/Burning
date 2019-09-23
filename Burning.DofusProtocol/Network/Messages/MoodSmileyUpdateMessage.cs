using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MoodSmileyUpdateMessage : NetworkMessage
  {
    public const uint Id = 6388;
    public uint accountId;
    public double playerId;
    public uint smileyId;

    public override uint MessageId
    {
      get
      {
        return 6388;
      }
    }

    public MoodSmileyUpdateMessage()
    {
    }

    public MoodSmileyUpdateMessage(uint accountId, double playerId, uint smileyId)
    {
      this.accountId = accountId;
      this.playerId = playerId;
      this.smileyId = smileyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element smileyId.");
      writer.WriteVarShort((short) this.smileyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of MoodSmileyUpdateMessage.accountId.");
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of MoodSmileyUpdateMessage.playerId.");
      this.smileyId = (uint) reader.ReadVarUhShort();
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element of MoodSmileyUpdateMessage.smileyId.");
    }
  }
}
