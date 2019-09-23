using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectUseOnCellMessage : ObjectUseMessage
  {
    public new const uint Id = 3013;
    public uint cells;

    public override uint MessageId
    {
      get
      {
        return 3013;
      }
    }

    public ObjectUseOnCellMessage()
    {
    }

    public ObjectUseOnCellMessage(uint objectUID, uint cells)
      : base(objectUID)
    {
      this.cells = cells;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.cells < 0U || this.cells > 559U)
        throw new Exception("Forbidden value (" + (object) this.cells + ") on element cells.");
      writer.WriteVarShort((short) this.cells);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.cells = (uint) reader.ReadVarUhShort();
      if (this.cells < 0U || this.cells > 559U)
        throw new Exception("Forbidden value (" + (object) this.cells + ") on element of ObjectUseOnCellMessage.cells.");
    }
  }
}
