using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatedElement
  {
    public const uint Id = 108;
    public uint elementId;
    public uint elementCellId;
    public uint elementState;
    public bool onCurrentMap;

    public virtual uint TypeId
    {
      get
      {
        return 108;
      }
    }

    public StatedElement()
    {
    }

    public StatedElement(uint elementId, uint elementCellId, uint elementState, bool onCurrentMap)
    {
      this.elementId = elementId;
      this.elementCellId = elementCellId;
      this.elementState = elementState;
      this.onCurrentMap = onCurrentMap;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element elementId.");
      writer.WriteInt((int) this.elementId);
      if (this.elementCellId < 0U || this.elementCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.elementCellId + ") on element elementCellId.");
      writer.WriteVarShort((short) this.elementCellId);
      if (this.elementState < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementState + ") on element elementState.");
      writer.WriteVarInt((int) this.elementState);
      writer.WriteBoolean(this.onCurrentMap);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.elementId = (uint) reader.ReadInt();
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element of StatedElement.elementId.");
      this.elementCellId = (uint) reader.ReadVarUhShort();
      if (this.elementCellId < 0U || this.elementCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.elementCellId + ") on element of StatedElement.elementCellId.");
      this.elementState = reader.ReadVarUhInt();
      if (this.elementState < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementState + ") on element of StatedElement.elementState.");
      this.onCurrentMap = reader.ReadBoolean();
    }
  }
}
