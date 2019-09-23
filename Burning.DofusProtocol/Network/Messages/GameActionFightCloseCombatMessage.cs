using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
  {
    public new const uint Id = 6116;
    public uint weaponGenericId;

    public override uint MessageId
    {
      get
      {
        return 6116;
      }
    }

    public GameActionFightCloseCombatMessage()
    {
    }

    public GameActionFightCloseCombatMessage(
      uint actionId,
      double sourceId,
      double targetId,
      int destinationCellId,
      uint critical,
      bool silentCast,
      bool verboseCast,
      uint weaponGenericId)
      : base(actionId, sourceId, targetId, destinationCellId, critical, silentCast, verboseCast)
    {
      this.weaponGenericId = weaponGenericId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.weaponGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.weaponGenericId + ") on element weaponGenericId.");
      writer.WriteVarShort((short) this.weaponGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.weaponGenericId = (uint) reader.ReadVarUhShort();
      if (this.weaponGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.weaponGenericId + ") on element of GameActionFightCloseCombatMessage.weaponGenericId.");
    }
  }
}
