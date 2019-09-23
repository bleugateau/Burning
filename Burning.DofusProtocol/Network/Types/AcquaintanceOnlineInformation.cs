using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AcquaintanceOnlineInformation : AcquaintanceInformation
  {
    public new const uint Id = 562;
    public double playerId;
    public string playerName;
    public uint moodSmileyId;
    public PlayerStatus status;

    public override uint TypeId
    {
      get
      {
        return 562;
      }
    }

    public AcquaintanceOnlineInformation()
    {
    }

    public AcquaintanceOnlineInformation(
      uint accountId,
      string accountName,
      uint playerState,
      double playerId,
      string playerName,
      uint moodSmileyId,
      PlayerStatus status)
      : base(accountId, accountName, playerState)
    {
      this.playerId = playerId;
      this.playerName = playerName;
      this.moodSmileyId = moodSmileyId;
      this.status = status;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
      if (this.moodSmileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.moodSmileyId + ") on element moodSmileyId.");
      writer.WriteVarShort((short) this.moodSmileyId);
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of AcquaintanceOnlineInformation.playerId.");
      this.playerName = reader.ReadUTF();
      this.moodSmileyId = (uint) reader.ReadVarUhShort();
      if (this.moodSmileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.moodSmileyId + ") on element of AcquaintanceOnlineInformation.moodSmileyId.");
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
    }
  }
}
