using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TitleSelectRequestMessage : NetworkMessage
  {
    public const uint Id = 6365;
    public uint titleId;

    public override uint MessageId
    {
      get
      {
        return 6365;
      }
    }

    public TitleSelectRequestMessage()
    {
    }

    public TitleSelectRequestMessage(uint titleId)
    {
      this.titleId = titleId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.titleId < 0U)
        throw new Exception("Forbidden value (" + (object) this.titleId + ") on element titleId.");
      writer.WriteVarShort((short) this.titleId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.titleId = (uint) reader.ReadVarUhShort();
      if (this.titleId < 0U)
        throw new Exception("Forbidden value (" + (object) this.titleId + ") on element of TitleSelectRequestMessage.titleId.");
    }
  }
}
