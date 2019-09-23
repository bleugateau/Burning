using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightNewRoundMessage : NetworkMessage
  {
    public const uint Id = 6239;
    public uint rounddouble;

    public override uint MessageId
    {
      get
      {
        return 6239;
      }
    }

    public GameFightNewRoundMessage()
    {
    }

    public GameFightNewRoundMessage(uint rounddouble)
    {
      this.rounddouble = rounddouble;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.rounddouble < 0U)
        throw new Exception("Forbidden value (" + (object) this.rounddouble + ") on element rounddouble.");
      writer.WriteVarInt((int) this.rounddouble);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.rounddouble = reader.ReadVarUhInt();
      if (this.rounddouble < 0U)
        throw new Exception("Forbidden value (" + (object) this.rounddouble + ") on element of GameFightNewRoundMessage.rounddouble.");
    }
  }
}
