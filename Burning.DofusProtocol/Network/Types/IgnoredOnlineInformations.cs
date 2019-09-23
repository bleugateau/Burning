using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class IgnoredOnlineInformations : IgnoredInformations
  {
    public new const uint Id = 105;
    public double playerId;
    public string playerName;
    public int breed;
    public bool sex;

    public override uint TypeId
    {
      get
      {
        return 105;
      }
    }

    public IgnoredOnlineInformations()
    {
    }

    public IgnoredOnlineInformations(
      uint accountId,
      string accountName,
      double playerId,
      string playerName,
      int breed,
      bool sex)
      : base(accountId, accountName)
    {
      this.playerId = playerId;
      this.playerName = playerName;
      this.breed = breed;
      this.sex = sex;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of IgnoredOnlineInformations.playerId.");
      this.playerName = reader.ReadUTF();
      this.breed = (int) reader.ReadByte();
      if (this.breed < 1 || this.breed > 18)
        throw new Exception("Forbidden value (" + (object) this.breed + ") on element of IgnoredOnlineInformations.breed.");
      this.sex = reader.ReadBoolean();
    }
  }
}
