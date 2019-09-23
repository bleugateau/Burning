using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaRegisterMessage : NetworkMessage
  {
    public const uint Id = 6280;
    public uint battleMode;

    public override uint MessageId
    {
      get
      {
        return 6280;
      }
    }

    public GameRolePlayArenaRegisterMessage()
    {
    }

    public GameRolePlayArenaRegisterMessage(uint battleMode)
    {
      this.battleMode = battleMode;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt((int) this.battleMode);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.battleMode = (uint) reader.ReadInt();
      if (this.battleMode < 0U)
        throw new Exception("Forbidden value (" + (object) this.battleMode + ") on element of GameRolePlayArenaRegisterMessage.battleMode.");
    }
  }
}
