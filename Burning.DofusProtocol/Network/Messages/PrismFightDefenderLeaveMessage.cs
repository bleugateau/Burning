using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightDefenderLeaveMessage : NetworkMessage
  {
    public const uint Id = 5892;
    public uint subAreaId;
    public uint fightId;
    public double fighterToRemoveId;

    public override uint MessageId
    {
      get
      {
        return 5892;
      }
    }

    public PrismFightDefenderLeaveMessage()
    {
    }

    public PrismFightDefenderLeaveMessage(uint subAreaId, uint fightId, double fighterToRemoveId)
    {
      this.subAreaId = subAreaId;
      this.fightId = fightId;
      this.fighterToRemoveId = fighterToRemoveId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      if (this.fighterToRemoveId < 0.0 || this.fighterToRemoveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fighterToRemoveId + ") on element fighterToRemoveId.");
      writer.WriteVarLong((long) this.fighterToRemoveId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismFightDefenderLeaveMessage.subAreaId.");
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of PrismFightDefenderLeaveMessage.fightId.");
      this.fighterToRemoveId = (double) reader.ReadVarUhLong();
      if (this.fighterToRemoveId < 0.0 || this.fighterToRemoveId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fighterToRemoveId + ") on element of PrismFightDefenderLeaveMessage.fighterToRemoveId.");
    }
  }
}
