using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectUseOnCharacterMessage : ObjectUseMessage
  {
    public new const uint Id = 3003;
    public double characterId;

    public override uint MessageId
    {
      get
      {
        return 3003;
      }
    }

    public ObjectUseOnCharacterMessage()
    {
    }

    public ObjectUseOnCharacterMessage(uint objectUID, double characterId)
      : base(objectUID)
    {
      this.characterId = characterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element characterId.");
      writer.WriteVarLong((long) this.characterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.characterId = (double) reader.ReadVarUhLong();
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element of ObjectUseOnCharacterMessage.characterId.");
    }
  }
}
