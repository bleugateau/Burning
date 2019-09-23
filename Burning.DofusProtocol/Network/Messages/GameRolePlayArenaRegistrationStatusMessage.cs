using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaRegistrationStatusMessage : NetworkMessage
  {
    public const uint Id = 6284;
    public bool registered;
    public uint step;
    public uint battleMode;

    public override uint MessageId
    {
      get
      {
        return 6284;
      }
    }

    public GameRolePlayArenaRegistrationStatusMessage()
    {
    }

    public GameRolePlayArenaRegistrationStatusMessage(bool registered, uint step, uint battleMode)
    {
      this.registered = registered;
      this.step = step;
      this.battleMode = battleMode;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.registered);
      writer.WriteByte((byte) this.step);
      writer.WriteInt((int) this.battleMode);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.registered = reader.ReadBoolean();
      this.step = (uint) reader.ReadByte();
      if (this.step < 0U)
        throw new Exception("Forbidden value (" + (object) this.step + ") on element of GameRolePlayArenaRegistrationStatusMessage.step.");
      this.battleMode = (uint) reader.ReadInt();
      if (this.battleMode < 0U)
        throw new Exception("Forbidden value (" + (object) this.battleMode + ") on element of GameRolePlayArenaRegistrationStatusMessage.battleMode.");
    }
  }
}
