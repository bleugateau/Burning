using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShowCellMessage : NetworkMessage
  {
    public const uint Id = 5612;
    public double sourceId;
    public uint cellId;

    public override uint MessageId
    {
      get
      {
        return 5612;
      }
    }

    public ShowCellMessage()
    {
    }

    public ShowCellMessage(double sourceId, uint cellId)
    {
      this.sourceId = sourceId;
      this.cellId = cellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element sourceId.");
      writer.WriteDouble(this.sourceId);
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.sourceId = reader.ReadDouble();
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element of ShowCellMessage.sourceId.");
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of ShowCellMessage.cellId.");
    }
  }
}
