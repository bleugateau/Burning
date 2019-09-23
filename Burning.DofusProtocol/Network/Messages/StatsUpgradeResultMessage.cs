using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StatsUpgradeResultMessage : NetworkMessage
  {
    public const uint Id = 5609;
    public int result;
    public uint nbCharacBoost;

    public override uint MessageId
    {
      get
      {
        return 5609;
      }
    }

    public StatsUpgradeResultMessage()
    {
    }

    public StatsUpgradeResultMessage(int result, uint nbCharacBoost)
    {
      this.result = result;
      this.nbCharacBoost = nbCharacBoost;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.result);
      if (this.nbCharacBoost < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbCharacBoost + ") on element nbCharacBoost.");
      writer.WriteVarShort((short) this.nbCharacBoost);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.result = (int) reader.ReadByte();
      this.nbCharacBoost = (uint) reader.ReadVarUhShort();
      if (this.nbCharacBoost < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbCharacBoost + ") on element of StatsUpgradeResultMessage.nbCharacBoost.");
    }
  }
}
