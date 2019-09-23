using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightHumanReadyStateMessage : NetworkMessage
  {
    public const uint Id = 740;
    public double characterId;
    public bool isReady;

    public override uint MessageId
    {
      get
      {
        return 740;
      }
    }

    public GameFightHumanReadyStateMessage()
    {
    }

    public GameFightHumanReadyStateMessage(double characterId, bool isReady)
    {
      this.characterId = characterId;
      this.isReady = isReady;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element characterId.");
      writer.WriteVarLong((long) this.characterId);
      writer.WriteBoolean(this.isReady);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.characterId = (double) reader.ReadVarUhLong();
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element of GameFightHumanReadyStateMessage.characterId.");
      this.isReady = reader.ReadBoolean();
    }
  }
}
