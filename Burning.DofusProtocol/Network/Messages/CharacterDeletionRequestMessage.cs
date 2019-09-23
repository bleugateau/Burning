using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterDeletionRequestMessage : NetworkMessage
  {
    public const uint Id = 165;
    public double characterId;
    public string secretAnswerHash;

    public override uint MessageId
    {
      get
      {
        return 165;
      }
    }

    public CharacterDeletionRequestMessage()
    {
    }

    public CharacterDeletionRequestMessage(double characterId, string secretAnswerHash)
    {
      this.characterId = characterId;
      this.secretAnswerHash = secretAnswerHash;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element characterId.");
      writer.WriteVarLong((long) this.characterId);
      writer.WriteUTF(this.secretAnswerHash);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.characterId = (double) reader.ReadVarUhLong();
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element of CharacterDeletionRequestMessage.characterId.");
      this.secretAnswerHash = reader.ReadUTF();
    }
  }
}
