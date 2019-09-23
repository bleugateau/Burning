using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
  {
    public const uint Id = 5731;
    public double targetId;
    public int targetCellId;
    public bool friendly;

    public override uint MessageId
    {
      get
      {
        return 5731;
      }
    }

    public GameRolePlayPlayerFightRequestMessage()
    {
    }

    public GameRolePlayPlayerFightRequestMessage(double targetId, int targetCellId, bool friendly)
    {
      this.targetId = targetId;
      this.targetCellId = targetCellId;
      this.friendly = friendly;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteVarLong((long) this.targetId);
      if (this.targetCellId < -1 || this.targetCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.targetCellId + ") on element targetCellId.");
      writer.WriteShort((short) this.targetCellId);
      writer.WriteBoolean(this.friendly);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.targetId = (double) reader.ReadVarUhLong();
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameRolePlayPlayerFightRequestMessage.targetId.");
      this.targetCellId = (int) reader.ReadShort();
      if (this.targetCellId < -1 || this.targetCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.targetCellId + ") on element of GameRolePlayPlayerFightRequestMessage.targetCellId.");
      this.friendly = reader.ReadBoolean();
    }
  }
}
