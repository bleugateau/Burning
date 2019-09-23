using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportBuddiesRequestedMessage : NetworkMessage
  {
    public List<double> invalidBuddiesIds = new List<double>();
    public const uint Id = 6302;
    public uint dungeonId;
    public double inviterId;

    public override uint MessageId
    {
      get
      {
        return 6302;
      }
    }

    public TeleportBuddiesRequestedMessage()
    {
    }

    public TeleportBuddiesRequestedMessage(
      uint dungeonId,
      double inviterId,
      List<double> invalidBuddiesIds)
    {
      this.dungeonId = dungeonId;
      this.inviterId = inviterId;
      this.invalidBuddiesIds = invalidBuddiesIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      if (this.inviterId < 0.0 || this.inviterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.inviterId + ") on element inviterId.");
      writer.WriteVarLong((long) this.inviterId);
      writer.WriteShort((short) this.invalidBuddiesIds.Count);
      for (int index = 0; index < this.invalidBuddiesIds.Count; ++index)
      {
        if (this.invalidBuddiesIds[index] < 0.0 || this.invalidBuddiesIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.invalidBuddiesIds[index] + ") on element 3 (starting at 1) of invalidBuddiesIds.");
        writer.WriteVarLong((long) this.invalidBuddiesIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of TeleportBuddiesRequestedMessage.dungeonId.");
      this.inviterId = (double) reader.ReadVarUhLong();
      if (this.inviterId < 0.0 || this.inviterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.inviterId + ") on element of TeleportBuddiesRequestedMessage.inviterId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = (double) reader.ReadVarUhLong();
        if (num2 < 0.0 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of invalidBuddiesIds.");
        this.invalidBuddiesIds.Add(num2);
      }
    }
  }
}
