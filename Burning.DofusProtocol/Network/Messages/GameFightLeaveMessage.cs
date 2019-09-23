using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightLeaveMessage : NetworkMessage
  {
    public const uint Id = 721;
    public double charId;

    public override uint MessageId
    {
      get
      {
        return 721;
      }
    }

    public GameFightLeaveMessage()
    {
    }

    public GameFightLeaveMessage(double charId)
    {
      this.charId = charId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.charId < -9.00719925474099E+15 || this.charId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.charId + ") on element charId.");
      writer.WriteDouble(this.charId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.charId = reader.ReadDouble();
      if (this.charId < -9.00719925474099E+15 || this.charId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.charId + ") on element of GameFightLeaveMessage.charId.");
    }
  }
}
