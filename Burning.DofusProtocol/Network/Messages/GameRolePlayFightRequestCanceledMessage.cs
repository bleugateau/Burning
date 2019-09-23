using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayFightRequestCanceledMessage : NetworkMessage
  {
    public const uint Id = 5822;
    public uint fightId;
    public double sourceId;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 5822;
      }
    }

    public GameRolePlayFightRequestCanceledMessage()
    {
    }

    public GameRolePlayFightRequestCanceledMessage(uint fightId, double sourceId, double targetId)
    {
      this.fightId = fightId;
      this.sourceId = sourceId;
      this.targetId = targetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element sourceId.");
      writer.WriteDouble(this.sourceId);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayFightRequestCanceledMessage.fightId.");
      this.sourceId = reader.ReadDouble();
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element of GameRolePlayFightRequestCanceledMessage.sourceId.");
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameRolePlayFightRequestCanceledMessage.targetId.");
    }
  }
}
