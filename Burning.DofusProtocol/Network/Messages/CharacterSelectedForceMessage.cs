using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterSelectedForceMessage : NetworkMessage
  {
    public const uint Id = 6068;
    public int id;

    public override uint MessageId
    {
      get
      {
        return 6068;
      }
    }

    public CharacterSelectedForceMessage()
    {
    }

    public CharacterSelectedForceMessage(int id)
    {
      this.id = id;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < 1 || this.id > int.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteInt(this.id);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadInt();
      if (this.id < 1 || this.id > int.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of CharacterSelectedForceMessage.id.");
    }
  }
}
