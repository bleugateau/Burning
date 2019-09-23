using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaFightAnswerMessage : NetworkMessage
  {
    public const uint Id = 6279;
    public uint fightId;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6279;
      }
    }

    public GameRolePlayArenaFightAnswerMessage()
    {
    }

    public GameRolePlayArenaFightAnswerMessage(uint fightId, bool accept)
    {
      this.fightId = fightId;
      this.accept = accept;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteBoolean(this.accept);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayArenaFightAnswerMessage.fightId.");
      this.accept = reader.ReadBoolean();
    }
  }
}
