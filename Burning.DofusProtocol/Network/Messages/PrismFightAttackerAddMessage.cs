using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightAttackerAddMessage : NetworkMessage
  {
    public const uint Id = 5893;
    public uint subAreaId;
    public uint fightId;
    public CharacterMinimalPlusLookInformations attacker;

    public override uint MessageId
    {
      get
      {
        return 5893;
      }
    }

    public PrismFightAttackerAddMessage()
    {
    }

    public PrismFightAttackerAddMessage(
      uint subAreaId,
      uint fightId,
      CharacterMinimalPlusLookInformations attacker)
    {
      this.subAreaId = subAreaId;
      this.fightId = fightId;
      this.attacker = attacker;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteShort((short) this.attacker.TypeId);
      this.attacker.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismFightAttackerAddMessage.subAreaId.");
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of PrismFightAttackerAddMessage.fightId.");
      this.attacker = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>((uint) reader.ReadUShort());
      this.attacker.Deserialize(reader);
    }
  }
}
