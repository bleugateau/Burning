using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightOptionStateUpdateMessage : NetworkMessage
  {
    public const uint Id = 5927;
    public uint fightId;
    public uint teamId;
    public uint option;
    public bool state;

    public override uint MessageId
    {
      get
      {
        return 5927;
      }
    }

    public GameFightOptionStateUpdateMessage()
    {
    }

    public GameFightOptionStateUpdateMessage(uint fightId, uint teamId, uint option, bool state)
    {
      this.fightId = fightId;
      this.teamId = teamId;
      this.option = option;
      this.state = state;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteByte((byte) this.teamId);
      writer.WriteByte((byte) this.option);
      writer.WriteBoolean(this.state);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameFightOptionStateUpdateMessage.fightId.");
      this.teamId = (uint) reader.ReadByte();
      if (this.teamId < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamId + ") on element of GameFightOptionStateUpdateMessage.teamId.");
      this.option = (uint) reader.ReadByte();
      if (this.option < 0U)
        throw new Exception("Forbidden value (" + (object) this.option + ") on element of GameFightOptionStateUpdateMessage.option.");
      this.state = reader.ReadBoolean();
    }
  }
}
