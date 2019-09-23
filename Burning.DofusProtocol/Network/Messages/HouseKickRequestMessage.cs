using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseKickRequestMessage : NetworkMessage
  {
    public const uint Id = 5698;
    public double id;

    public override uint MessageId
    {
      get
      {
        return 5698;
      }
    }

    public HouseKickRequestMessage()
    {
    }

    public HouseKickRequestMessage(double id)
    {
      this.id = id;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarLong((long) this.id);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = (double) reader.ReadVarUhLong();
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of HouseKickRequestMessage.id.");
    }
  }
}
