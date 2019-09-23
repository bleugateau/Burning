using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightDefenderAddMessage : NetworkMessage
  {
    public const uint Id = 5895;
    public uint subAreaId;
    public uint fightId;
    public CharacterMinimalPlusLookInformations defender;

    public override uint MessageId
    {
      get
      {
        return 5895;
      }
    }

    public PrismFightDefenderAddMessage()
    {
    }

    public PrismFightDefenderAddMessage(
      uint subAreaId,
      uint fightId,
      CharacterMinimalPlusLookInformations defender)
    {
      this.subAreaId = subAreaId;
      this.fightId = fightId;
      this.defender = defender;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteShort((short) this.defender.TypeId);
      this.defender.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismFightDefenderAddMessage.subAreaId.");
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of PrismFightDefenderAddMessage.fightId.");
      this.defender = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>((uint) reader.ReadUShort());
      this.defender.Deserialize(reader);
    }
  }
}
