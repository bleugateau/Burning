using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterExperienceGainMessage : NetworkMessage
  {
    public const uint Id = 6321;
    public double experienceCharacter;
    public double experienceMount;
    public double experienceGuild;
    public double experienceIncarnation;

    public override uint MessageId
    {
      get
      {
        return 6321;
      }
    }

    public CharacterExperienceGainMessage()
    {
    }

    public CharacterExperienceGainMessage(
      double experienceCharacter,
      double experienceMount,
      double experienceGuild,
      double experienceIncarnation)
    {
      this.experienceCharacter = experienceCharacter;
      this.experienceMount = experienceMount;
      this.experienceGuild = experienceGuild;
      this.experienceIncarnation = experienceIncarnation;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.experienceCharacter < 0.0 || this.experienceCharacter > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceCharacter + ") on element experienceCharacter.");
      writer.WriteVarLong((long) this.experienceCharacter);
      if (this.experienceMount < 0.0 || this.experienceMount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceMount + ") on element experienceMount.");
      writer.WriteVarLong((long) this.experienceMount);
      if (this.experienceGuild < 0.0 || this.experienceGuild > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceGuild + ") on element experienceGuild.");
      writer.WriteVarLong((long) this.experienceGuild);
      if (this.experienceIncarnation < 0.0 || this.experienceIncarnation > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceIncarnation + ") on element experienceIncarnation.");
      writer.WriteVarLong((long) this.experienceIncarnation);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.experienceCharacter = (double) reader.ReadVarUhLong();
      if (this.experienceCharacter < 0.0 || this.experienceCharacter > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceCharacter + ") on element of CharacterExperienceGainMessage.experienceCharacter.");
      this.experienceMount = (double) reader.ReadVarUhLong();
      if (this.experienceMount < 0.0 || this.experienceMount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceMount + ") on element of CharacterExperienceGainMessage.experienceMount.");
      this.experienceGuild = (double) reader.ReadVarUhLong();
      if (this.experienceGuild < 0.0 || this.experienceGuild > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceGuild + ") on element of CharacterExperienceGainMessage.experienceGuild.");
      this.experienceIncarnation = (double) reader.ReadVarUhLong();
      if (this.experienceIncarnation < 0.0 || this.experienceIncarnation > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceIncarnation + ") on element of CharacterExperienceGainMessage.experienceIncarnation.");
    }
  }
}
