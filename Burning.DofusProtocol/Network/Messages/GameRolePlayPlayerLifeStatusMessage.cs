using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayPlayerLifeStatusMessage : NetworkMessage
  {
    public const uint Id = 5996;
    public uint state;
    public double phenixMapId;

    public override uint MessageId
    {
      get
      {
        return 5996;
      }
    }

    public GameRolePlayPlayerLifeStatusMessage()
    {
    }

    public GameRolePlayPlayerLifeStatusMessage(uint state, double phenixMapId)
    {
      this.state = state;
      this.phenixMapId = phenixMapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.state);
      if (this.phenixMapId < 0.0 || this.phenixMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.phenixMapId + ") on element phenixMapId.");
      writer.WriteDouble(this.phenixMapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.state = (uint) reader.ReadByte();
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element of GameRolePlayPlayerLifeStatusMessage.state.");
      this.phenixMapId = reader.ReadDouble();
      if (this.phenixMapId < 0.0 || this.phenixMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.phenixMapId + ") on element of GameRolePlayPlayerLifeStatusMessage.phenixMapId.");
    }
  }
}
