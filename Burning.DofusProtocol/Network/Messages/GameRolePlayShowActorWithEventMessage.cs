using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
  {
    public new const uint Id = 6407;
    public uint actorEventId;

    public override uint MessageId
    {
      get
      {
        return 6407;
      }
    }

    public GameRolePlayShowActorWithEventMessage()
    {
    }

    public GameRolePlayShowActorWithEventMessage(
      GameRolePlayActorInformations informations,
      uint actorEventId)
      : base(informations)
    {
      this.actorEventId = actorEventId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.actorEventId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actorEventId + ") on element actorEventId.");
      writer.WriteByte((byte) this.actorEventId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.actorEventId = (uint) reader.ReadByte();
      if (this.actorEventId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actorEventId + ") on element of GameRolePlayShowActorWithEventMessage.actorEventId.");
    }
  }
}
