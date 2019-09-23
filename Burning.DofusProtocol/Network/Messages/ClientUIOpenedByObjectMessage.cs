using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage
  {
    public new const uint Id = 6463;
    public uint uid;

    public override uint MessageId
    {
      get
      {
        return 6463;
      }
    }

    public ClientUIOpenedByObjectMessage()
    {
    }

    public ClientUIOpenedByObjectMessage(uint type, uint uid)
      : base(type)
    {
      this.uid = uid;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element uid.");
      writer.WriteVarInt((int) this.uid);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.uid = reader.ReadVarUhInt();
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element of ClientUIOpenedByObjectMessage.uid.");
    }
  }
}
