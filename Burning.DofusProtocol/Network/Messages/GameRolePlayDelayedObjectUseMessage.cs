using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
  {
    public new const uint Id = 6425;
    public uint objectGID;

    public override uint MessageId
    {
      get
      {
        return 6425;
      }
    }

    public GameRolePlayDelayedObjectUseMessage()
    {
    }

    public GameRolePlayDelayedObjectUseMessage(
      double delayedCharacterId,
      uint delayTypeId,
      double delayEndTime,
      uint objectGID)
      : base(delayedCharacterId, delayTypeId, delayEndTime)
    {
      this.objectGID = objectGID;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of GameRolePlayDelayedObjectUseMessage.objectGID.");
    }
  }
}
