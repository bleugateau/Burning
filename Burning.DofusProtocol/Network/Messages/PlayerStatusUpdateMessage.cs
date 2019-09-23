using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PlayerStatusUpdateMessage : NetworkMessage
  {
    public const uint Id = 6386;
    public uint accountId;
    public double playerId;
    public PlayerStatus status;

    public override uint MessageId
    {
      get
      {
        return 6386;
      }
    }

    public PlayerStatusUpdateMessage()
    {
    }

    public PlayerStatusUpdateMessage(uint accountId, double playerId, PlayerStatus status)
    {
      this.accountId = accountId;
      this.playerId = playerId;
      this.status = status;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of PlayerStatusUpdateMessage.accountId.");
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of PlayerStatusUpdateMessage.playerId.");
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
    }
  }
}
