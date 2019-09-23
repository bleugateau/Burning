using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
  {
    public new const uint Id = 6010;
    public uint objectUID;

    public override uint MessageId
    {
      get
      {
        return 6010;
      }
    }

    public ExchangeObjectRemovedFromBagMessage()
    {
    }

    public ExchangeObjectRemovedFromBagMessage(bool remote, uint objectUID)
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
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ExchangeObjectRemovedFromBagMessage.objectUID.");
    }
  }
}
