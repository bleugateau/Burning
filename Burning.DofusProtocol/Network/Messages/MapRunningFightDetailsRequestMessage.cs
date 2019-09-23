using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapRunningFightDetailsRequestMessage : NetworkMessage
  {
    public const uint Id = 5750;
    public uint fightId;

    public override uint MessageId
    {
      get
      {
        return 5750;
      }
    }

    public MapRunningFightDetailsRequestMessage()
    {
    }

    public MapRunningFightDetailsRequestMessage(uint fightId)
    {
      this.fightId = fightId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of MapRunningFightDetailsRequestMessage.fightId.");
    }
  }
}
