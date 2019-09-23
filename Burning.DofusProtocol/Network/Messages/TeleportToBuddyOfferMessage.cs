using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportToBuddyOfferMessage : NetworkMessage
  {
    public const uint Id = 6287;
    public uint dungeonId;
    public double buddyId;
    public uint timeLeft;

    public override uint MessageId
    {
      get
      {
        return 6287;
      }
    }

    public TeleportToBuddyOfferMessage()
    {
    }

    public TeleportToBuddyOfferMessage(uint dungeonId, double buddyId, uint timeLeft)
    {
      this.dungeonId = dungeonId;
      this.buddyId = buddyId;
      this.timeLeft = timeLeft;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      if (this.buddyId < 0.0 || this.buddyId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.buddyId + ") on element buddyId.");
      writer.WriteVarLong((long) this.buddyId);
      if (this.timeLeft < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeLeft + ") on element timeLeft.");
      writer.WriteVarInt((int) this.timeLeft);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of TeleportToBuddyOfferMessage.dungeonId.");
      this.buddyId = (double) reader.ReadVarUhLong();
      if (this.buddyId < 0.0 || this.buddyId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.buddyId + ") on element of TeleportToBuddyOfferMessage.buddyId.");
      this.timeLeft = reader.ReadVarUhInt();
      if (this.timeLeft < 0U)
        throw new Exception("Forbidden value (" + (object) this.timeLeft + ") on element of TeleportToBuddyOfferMessage.timeLeft.");
    }
  }
}
