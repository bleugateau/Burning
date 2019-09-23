using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapRewardRateMessage : NetworkMessage
  {
    public const uint Id = 6827;
    public int mapRate;
    public int subAreaRate;
    public int totalRate;

    public override uint MessageId
    {
      get
      {
        return 6827;
      }
    }

    public MapRewardRateMessage()
    {
    }

    public MapRewardRateMessage(int mapRate, int subAreaRate, int totalRate)
    {
      this.mapRate = mapRate;
      this.subAreaRate = subAreaRate;
      this.totalRate = totalRate;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteVarShort((short) this.mapRate);
      writer.WriteVarShort((short) this.subAreaRate);
      writer.WriteVarShort((short) this.totalRate);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapRate = (int) reader.ReadVarShort();
      this.subAreaRate = (int) reader.ReadVarShort();
      this.totalRate = (int) reader.ReadVarShort();
    }
  }
}
