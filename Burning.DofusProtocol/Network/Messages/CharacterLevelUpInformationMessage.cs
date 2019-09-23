using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
  {
    public new const uint Id = 6076;
    public string name;
    public double id;

    public override uint MessageId
    {
      get
      {
        return 6076;
      }
    }

    public CharacterLevelUpInformationMessage()
    {
    }

    public CharacterLevelUpInformationMessage(uint newLevel, string name, double id)
      : base(newLevel)
    {
      this.name = name;
      this.id = id;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.name);
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarLong((long) this.id);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.name = reader.ReadUTF();
      this.id = (double) reader.ReadVarUhLong();
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of CharacterLevelUpInformationMessage.id.");
    }
  }
}
