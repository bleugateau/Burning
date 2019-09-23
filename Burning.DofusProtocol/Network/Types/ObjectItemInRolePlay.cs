using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemInRolePlay
  {
    public const uint Id = 198;
    public uint cellId;
    public uint objectGID;

    public virtual uint TypeId
    {
      get
      {
        return 198;
      }
    }

    public ObjectItemInRolePlay()
    {
    }

    public ObjectItemInRolePlay(uint cellId, uint objectGID)
    {
      this.cellId = cellId;
      this.objectGID = objectGID;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of ObjectItemInRolePlay.cellId.");
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ObjectItemInRolePlay.objectGID.");
    }
  }
}
