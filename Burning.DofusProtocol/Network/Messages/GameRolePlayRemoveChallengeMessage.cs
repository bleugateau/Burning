using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayRemoveChallengeMessage : NetworkMessage
  {
    public const uint Id = 300;
    public uint fightId;

    public override uint MessageId
    {
      get
      {
        return 300;
      }
    }

    public GameRolePlayRemoveChallengeMessage()
    {
    }

    public GameRolePlayRemoveChallengeMessage(uint fightId)
    {
      this.fightId = fightId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayRemoveChallengeMessage.fightId.");
    }
  }
}
