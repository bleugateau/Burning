using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
  {
    public new const uint Id = 6245;
    public uint dungeonId;

    public override uint MessageId
    {
      get
      {
        return 6245;
      }
    }

    public PartyInvitationDungeonRequestMessage()
    {
    }

    public PartyInvitationDungeonRequestMessage(string name, uint dungeonId)
      : base(name)
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
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of PartyInvitationDungeonRequestMessage.dungeonId.");
    }
  }
}
