using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationDungeonMessage : PartyInvitationMessage
  {
    public new const uint Id = 6244;
    public uint dungeonId;

    public override uint MessageId
    {
      get
      {
        return 6244;
      }
    }

    public PartyInvitationDungeonMessage()
    {
    }

    public PartyInvitationDungeonMessage(
      uint partyId,
      uint partyType,
      string partyName,
      uint maxParticipants,
      double fromId,
      string fromName,
      double toId,
      uint dungeonId)
      : base(partyId, partyType, partyName, maxParticipants, fromId, fromName, toId)
    {
      this.dungeonId = dungeonId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of PartyInvitationDungeonMessage.dungeonId.");
    }
  }
}
