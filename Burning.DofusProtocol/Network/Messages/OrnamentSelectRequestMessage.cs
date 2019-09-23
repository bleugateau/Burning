using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class OrnamentSelectRequestMessage : NetworkMessage
  {
    public const uint Id = 6374;
    public uint ornamentId;

    public override uint MessageId
    {
      get
      {
        return 6374;
      }
    }

    public OrnamentSelectRequestMessage()
    {
    }

    public OrnamentSelectRequestMessage(uint ornamentId)
    {
      this.ornamentId = ornamentId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.ornamentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ornamentId + ") on element ornamentId.");
      writer.WriteVarShort((short) this.ornamentId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.ornamentId = (uint) reader.ReadVarUhShort();
      if (this.ornamentId < 0U)
        throw new Exception("Forbidden value (" + (object) this.ornamentId + ") on element of OrnamentSelectRequestMessage.ornamentId.");
    }
  }
}
