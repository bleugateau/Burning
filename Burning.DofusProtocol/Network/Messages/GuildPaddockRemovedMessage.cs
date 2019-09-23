using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildPaddockRemovedMessage : NetworkMessage
  {
    public const uint Id = 5955;
    public double paddockId;

    public override uint MessageId
    {
      get
      {
        return 5955;
      }
    }

    public GuildPaddockRemovedMessage()
    {
    }

    public GuildPaddockRemovedMessage(double paddockId)
    {
      this.paddockId = paddockId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.paddockId < 0.0 || this.paddockId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.paddockId + ") on element paddockId.");
      writer.WriteDouble(this.paddockId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.paddockId = reader.ReadDouble();
      if (this.paddockId < 0.0 || this.paddockId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.paddockId + ") on element of GuildPaddockRemovedMessage.paddockId.");
    }
  }
}
