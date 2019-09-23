using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextKickMessage : NetworkMessage
  {
    public const uint Id = 6081;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 6081;
      }
    }

    public GameContextKickMessage()
    {
    }

    public GameContextKickMessage(double targetId)
    {
      this.targetId = targetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameContextKickMessage.targetId.");
    }
  }
}
