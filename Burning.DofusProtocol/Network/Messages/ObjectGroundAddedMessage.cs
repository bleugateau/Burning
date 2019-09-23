using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectGroundAddedMessage : NetworkMessage
  {
    public const uint Id = 3017;
    public uint cellId;
    public uint objectGID;

    public override uint MessageId
    {
      get
      {
        return 3017;
      }
    }

    public ObjectGroundAddedMessage()
    {
    }

    public ObjectGroundAddedMessage(uint cellId, uint objectGID)
    {
      this.cellId = cellId;
      this.objectGID = objectGID;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of ObjectGroundAddedMessage.cellId.");
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ObjectGroundAddedMessage.objectGID.");
    }
  }
}
