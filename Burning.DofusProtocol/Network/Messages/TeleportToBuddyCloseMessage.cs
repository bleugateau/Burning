using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportToBuddyCloseMessage : NetworkMessage
  {
    public const uint Id = 6303;
    public uint dungeonId;
    public double buddyId;

    public override uint MessageId
    {
      get
      {
        return 6303;
      }
    }

    public TeleportToBuddyCloseMessage()
    {
    }

    public TeleportToBuddyCloseMessage(uint dungeonId, double buddyId)
    {
      this.dungeonId = dungeonId;
      this.buddyId = buddyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      if (this.buddyId < 0.0 || this.buddyId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.buddyId + ") on element buddyId.");
      writer.WriteVarLong((long) this.buddyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of TeleportToBuddyCloseMessage.dungeonId.");
      this.buddyId = (double) reader.ReadVarUhLong();
      if (this.buddyId < 0.0 || this.buddyId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.buddyId + ") on element of TeleportToBuddyCloseMessage.buddyId.");
    }
  }
}
