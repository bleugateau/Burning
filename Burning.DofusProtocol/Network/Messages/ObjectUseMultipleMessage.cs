using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectUseMultipleMessage : ObjectUseMessage
  {
    public new const uint Id = 6234;
    public uint quantity;

    public override uint MessageId
    {
      get
      {
        return 6234;
      }
    }

    public ObjectUseMultipleMessage()
    {
    }

    public ObjectUseMultipleMessage(uint objectUID, uint quantity)
      : base(objectUID)
    {
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectUseMultipleMessage.quantity.");
    }
  }
}
