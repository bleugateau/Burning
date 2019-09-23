using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectGroundRemovedMessage : NetworkMessage
  {
    public const uint Id = 3014;
    public uint cell;

    public override uint MessageId
    {
      get
      {
        return 3014;
      }
    }

    public ObjectGroundRemovedMessage()
    {
    }

    public ObjectGroundRemovedMessage(uint cell)
    {
      this.cell = cell;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.cell < 0U || this.cell > 559U)
        throw new Exception("Forbidden value (" + (object) this.cell + ") on element cell.");
      writer.WriteVarShort((short) this.cell);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.cell = (uint) reader.ReadVarUhShort();
      if (this.cell < 0U || this.cell > 559U)
        throw new Exception("Forbidden value (" + (object) this.cell + ") on element of ObjectGroundRemovedMessage.cell.");
    }
  }
}
