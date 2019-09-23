using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportToBuddyAnswerMessage : NetworkMessage
  {
    public const uint Id = 6293;
    public uint dungeonId;
    public double buddyId;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6293;
      }
    }

    public TeleportToBuddyAnswerMessage()
    {
    }

    public TeleportToBuddyAnswerMessage(uint dungeonId, double buddyId, bool accept)
    {
      this.dungeonId = dungeonId;
      this.buddyId = buddyId;
      this.accept = accept;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      if (this.buddyId < 0.0 || this.buddyId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.buddyId + ") on element buddyId.");
      writer.WriteVarLong((long) this.buddyId);
      writer.WriteBoolean(this.accept);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of TeleportToBuddyAnswerMessage.dungeonId.");
      this.buddyId = (double) reader.ReadVarUhLong();
      if (this.buddyId < 0.0 || this.buddyId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.buddyId + ") on element of TeleportToBuddyAnswerMessage.buddyId.");
      this.accept = reader.ReadBoolean();
    }
  }
}
