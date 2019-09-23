using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportOnSameMapMessage : NetworkMessage
  {
    public const uint Id = 6048;
    public double targetId;
    public uint cellId;

    public override uint MessageId
    {
      get
      {
        return 6048;
      }
    }

    public TeleportOnSameMapMessage()
    {
    }

    public TeleportOnSameMapMessage(double targetId, uint cellId)
    {
      this.targetId = targetId;
      this.cellId = cellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of TeleportOnSameMapMessage.targetId.");
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of TeleportOnSameMapMessage.cellId.");
    }
  }
}
