using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ItemForPreset
  {
    public const uint Id = 540;
    public uint position;
    public uint objGid;
    public uint objUid;

    public virtual uint TypeId
    {
      get
      {
        return 540;
      }
    }

    public ItemForPreset()
    {
    }

    public ItemForPreset(uint position, uint objGid, uint objUid)
    {
      this.position = position;
      this.objGid = objGid;
      this.objUid = objUid;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.position);
      if (this.objGid < 0U)
        throw new Exception("Forbidden value (" + (object) this.objGid + ") on element objGid.");
      writer.WriteVarShort((short) this.objGid);
      if (this.objUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.objUid + ") on element objUid.");
      writer.WriteVarInt((int) this.objUid);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.position = (uint) reader.ReadShort();
      if (this.position < 0U)
        throw new Exception("Forbidden value (" + (object) this.position + ") on element of ItemForPreset.position.");
      this.objGid = (uint) reader.ReadVarUhShort();
      if (this.objGid < 0U)
        throw new Exception("Forbidden value (" + (object) this.objGid + ") on element of ItemForPreset.objGid.");
      this.objUid = reader.ReadVarUhInt();
      if (this.objUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.objUid + ") on element of ItemForPreset.objUid.");
    }
  }
}
