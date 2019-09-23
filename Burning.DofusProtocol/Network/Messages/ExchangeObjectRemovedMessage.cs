using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectRemovedMessage : ExchangeObjectMessage
  {
    public new const uint Id = 5517;
    public uint objectUID;

    public override uint MessageId
    {
      get
      {
        return 5517;
      }
    }

    public ExchangeObjectRemovedMessage()
    {
    }

    public ExchangeObjectRemovedMessage(bool remote, uint objectUID)
      : base(remote)
    {
      this.objectUID = objectUID;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ExchangeObjectRemovedMessage.objectUID.");
    }
  }
}
