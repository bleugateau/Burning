using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayPlayerFightFriendlyAnswerMessage : NetworkMessage
  {
    public const uint Id = 5732;
    public uint fightId;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 5732;
      }
    }

    public GameRolePlayPlayerFightFriendlyAnswerMessage()
    {
    }

    public GameRolePlayPlayerFightFriendlyAnswerMessage(uint fightId, bool accept)
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
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayPlayerFightFriendlyAnswerMessage.fightId.");
      this.accept = reader.ReadBoolean();
    }
  }
}
