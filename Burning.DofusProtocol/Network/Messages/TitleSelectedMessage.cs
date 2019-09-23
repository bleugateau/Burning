using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TitleSelectedMessage : NetworkMessage
  {
    public const uint Id = 6366;
    public uint titleId;

    public override uint MessageId
    {
      get
      {
        return 6366;
      }
    }

    public TitleSelectedMessage()
    {
    }

    public TitleSelectedMessage(uint titleId)
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
        throw new Exception("Forbidden value (" + (object) this.titleId + ") on element of TitleSelectedMessage.titleId.");
    }
  }
}
