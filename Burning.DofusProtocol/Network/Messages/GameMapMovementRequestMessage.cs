using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameMapMovementRequestMessage : NetworkMessage
  {
    public List<uint> keyMovements = new List<uint>();
    public const uint Id = 950;
    public double mapId;

    public override uint MessageId
    {
      get
      {
        return 950;
      }
    }

    public GameMapMovementRequestMessage()
    {
    }

    public GameMapMovementRequestMessage(List<uint> keyMovements, double mapId)
    {
      this.keyMovements = keyMovements;
      this.mapId = mapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.keyMovements.Count);
      for (int index = 0; index < this.keyMovements.Count; ++index)
      {
        if (this.keyMovements[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.keyMovements[index] + ") on element 1 (starting at 1) of keyMovements.");
        writer.WriteShort((short) this.keyMovements[index]);
      }
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of keyMovements.");
        this.keyMovements.Add(num2);
      }
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of GameMapMovementRequestMessage.mapId.");
    }
  }
}
