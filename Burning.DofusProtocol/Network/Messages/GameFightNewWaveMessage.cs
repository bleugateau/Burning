using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightNewWaveMessage : NetworkMessage
  {
    public const uint Id = 6490;
    public uint id;
    public uint teamId;
    public int nbTurnBeforeNextWave;

    public override uint MessageId
    {
      get
      {
        return 6490;
      }
    }

    public GameFightNewWaveMessage()
    {
    }

    public GameFightNewWaveMessage(uint id, uint teamId, int nbTurnBeforeNextWave)
    {
      this.id = id;
      this.teamId = teamId;
      this.nbTurnBeforeNextWave = nbTurnBeforeNextWave;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteByte((byte) this.id);
      writer.WriteByte((byte) this.teamId);
      writer.WriteShort((short) this.nbTurnBeforeNextWave);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadByte();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of GameFightNewWaveMessage.id.");
      this.teamId = (uint) reader.ReadByte();
      if (this.teamId < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamId + ") on element of GameFightNewWaveMessage.teamId.");
      this.nbTurnBeforeNextWave = (int) reader.ReadShort();
    }
  }
}
