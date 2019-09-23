using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextRemoveElementMessage : NetworkMessage
  {
    public const uint Id = 251;
    public double id;

    public override uint MessageId
    {
      get
      {
        return 251;
      }
    }

    public GameContextRemoveElementMessage()
    {
    }

    public GameContextRemoveElementMessage(double id)
    {
      this.id = id;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of GameContextRemoveElementMessage.id.");
    }
  }
}
