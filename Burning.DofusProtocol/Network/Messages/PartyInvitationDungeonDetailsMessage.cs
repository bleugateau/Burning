using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
  {
    public List<bool> playersDungeonReady = new List<bool>();
    public new const uint Id = 6262;
    public uint dungeonId;

    public override uint MessageId
    {
      get
      {
        return 6262;
      }
    }

    public PartyInvitationDungeonDetailsMessage()
    {
    }

    public PartyInvitationDungeonDetailsMessage(
      uint partyId,
      uint partyType,
      string partyName,
      double fromId,
      string fromName,
      double leaderId,
      List<PartyInvitationMemberInformations> members,
      List<PartyGuestInformations> guests,
      uint dungeonId,
      List<bool> playersDungeonReady)
      : base(partyId, partyType, partyName, fromId, fromName, leaderId, members, guests)
    {
      this.dungeonId = dungeonId;
      this.playersDungeonReady = playersDungeonReady;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      writer.WriteShort((short) this.playersDungeonReady.Count);
      for (int index = 0; index < this.playersDungeonReady.Count; ++index)
        writer.WriteBoolean(this.playersDungeonReady[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of PartyInvitationDungeonDetailsMessage.dungeonId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.playersDungeonReady.Add(reader.ReadBoolean());
    }
  }
}
