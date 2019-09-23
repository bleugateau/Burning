using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CinematicMessage : NetworkMessage
  {
    public const uint Id = 6053;
    public uint cinematicId;

    public override uint MessageId
    {
      get
      {
        return 6053;
      }
    }

    public CinematicMessage()
    {
    }

    public CinematicMessage(uint cinematicId)
    {
      this.cinematicId = cinematicId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.cinematicId < 0U)
        throw new Exception("Forbidden value (" + (object) this.cinematicId + ") on element cinematicId.");
      writer.WriteVarShort((short) this.cinematicId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.cinematicId = (uint) reader.ReadVarUhShort();
      if (this.cinematicId < 0U)
        throw new Exception("Forbidden value (" + (object) this.cinematicId + ") on element of CinematicMessage.cinematicId.");
    }
  }
}
