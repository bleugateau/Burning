using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterReplayRequestMessage : NetworkMessage
  {
    public const uint Id = 167;
    public double characterId;

    public override uint MessageId
    {
      get
      {
        return 167;
      }
    }

    public CharacterReplayRequestMessage()
    {
    }

    public CharacterReplayRequestMessage(double characterId)
    {
      this.characterId = characterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element characterId.");
      writer.WriteVarLong((long) this.characterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.characterId = (double) reader.ReadVarUhLong();
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element of CharacterReplayRequestMessage.characterId.");
    }
  }
}
