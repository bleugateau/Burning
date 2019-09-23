using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayDelayedActionFinishedMessage : NetworkMessage
  {
    public const uint Id = 6150;
    public double delayedCharacterId;
    public uint delayTypeId;

    public override uint MessageId
    {
      get
      {
        return 6150;
      }
    }

    public GameRolePlayDelayedActionFinishedMessage()
    {
    }

    public GameRolePlayDelayedActionFinishedMessage(double delayedCharacterId, uint delayTypeId)
    {
      this.delayedCharacterId = delayedCharacterId;
      this.delayTypeId = delayTypeId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.delayedCharacterId < -9.00719925474099E+15 || this.delayedCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayedCharacterId + ") on element delayedCharacterId.");
      writer.WriteDouble(this.delayedCharacterId);
      writer.WriteByte((byte) this.delayTypeId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.delayedCharacterId = reader.ReadDouble();
      if (this.delayedCharacterId < -9.00719925474099E+15 || this.delayedCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.delayedCharacterId + ") on element of GameRolePlayDelayedActionFinishedMessage.delayedCharacterId.");
      this.delayTypeId = (uint) reader.ReadByte();
      if (this.delayTypeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.delayTypeId + ") on element of GameRolePlayDelayedActionFinishedMessage.delayTypeId.");
    }
  }
}
