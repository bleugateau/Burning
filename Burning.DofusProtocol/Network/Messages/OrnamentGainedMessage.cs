using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class OrnamentGainedMessage : NetworkMessage
  {
    public const uint Id = 6368;
    public uint ornamentId;

    public override uint MessageId
    {
      get
      {
        return 6368;
      }
    }

    public OrnamentGainedMessage()
    {
    }

    public OrnamentGainedMessage(uint ornamentId)
    {
      this.ornamentId = ornamentId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.ornamentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ornamentId + ") on element ornamentId.");
      writer.WriteShort((short) this.ornamentId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.ornamentId = (uint) reader.ReadShort();
      if (this.ornamentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ornamentId + ") on element of OrnamentGainedMessage.ornamentId.");
    }
  }
}
