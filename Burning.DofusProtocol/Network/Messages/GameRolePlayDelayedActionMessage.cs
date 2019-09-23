using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayDelayedActionMessage : NetworkMessage
  {
    public const uint Id = 6153;
    public double delayedCharacterId;
    public uint delayTypeId;
    public double delayEndTime;

    public override uint MessageId
    {
      get
      {
        return 6153;
      }
    }

    public GameRolePlayDelayedActionMessage()
    {
    }

    public GameRolePlayDelayedActionMessage(
      double delayedCharacterId,
      uint delayTypeId,
      double delayEndTime)
    {
      this.delayedCharacterId = delayedCharacterId;
      this.delayTypeId = delayTypeId;
      this.delayEndTime = delayEndTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.delayedCharacterId < -9.00719925474099E+15 || this.delayedCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayedCharacterId + ") on element delayedCharacterId.");
      writer.WriteDouble(this.delayedCharacterId);
      writer.WriteByte((byte) this.delayTypeId);
      if (this.delayEndTime < 0.0 || this.delayEndTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayEndTime + ") on element delayEndTime.");
      writer.WriteDouble(this.delayEndTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.delayedCharacterId = reader.ReadDouble();
      if (this.delayedCharacterId < -9.00719925474099E+15 || this.delayedCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayedCharacterId + ") on element of GameRolePlayDelayedActionMessage.delayedCharacterId.");
      this.delayTypeId = (uint) reader.ReadByte();
      if (this.delayTypeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.delayTypeId + ") on element of GameRolePlayDelayedActionMessage.delayTypeId.");
      this.delayEndTime = reader.ReadDouble();
      if (this.delayEndTime < 0.0 || this.delayEndTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayEndTime + ") on element of GameRolePlayDelayedActionMessage.delayEndTime.");
    }
  }
}
