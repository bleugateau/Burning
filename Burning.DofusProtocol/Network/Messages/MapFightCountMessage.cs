using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapFightCountMessage : NetworkMessage
  {
    public const uint Id = 210;
    public uint fightCount;

    public override uint MessageId
    {
      get
      {
        return 210;
      }
    }

    public MapFightCountMessage()
    {
    }

    public MapFightCountMessage(uint fightCount)
    {
      this.fightCount = fightCount;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightCount + ") on element fightCount.");
      writer.WriteVarShort((short) this.fightCount);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightCount = (uint) reader.ReadVarUhShort();
      if (this.fightCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightCount + ") on element of MapFightCountMessage.fightCount.");
    }
  }
}
