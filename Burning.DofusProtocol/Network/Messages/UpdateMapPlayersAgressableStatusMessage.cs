using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
  {
    public List<double> playerIds = new List<double>();
    public List<uint> enable = new List<uint>();
    public const uint Id = 6454;

    public override uint MessageId
    {
      get
      {
        return 6454;
      }
    }

    public UpdateMapPlayersAgressableStatusMessage()
    {
    }

    public UpdateMapPlayersAgressableStatusMessage(List<double> playerIds, List<uint> enable)
    {
      this.playerIds = playerIds;
      this.enable = enable;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.playerIds.Count);
      for (int index = 0; index < this.playerIds.Count; ++index)
      {
        if (this.playerIds[index] < 0.0 || this.playerIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.playerIds[index] + ") on element 1 (starting at 1) of playerIds.");
        writer.WriteVarLong((long) this.playerIds[index]);
      }
      writer.WriteShort((short) this.enable.Count);
      for (int index = 0; index < this.enable.Count; ++index)
        writer.WriteByte((byte) this.enable[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = (double) reader.ReadVarUhLong();
        if (num2 < 0.0 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of playerIds.");
        this.playerIds.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of enable.");
        this.enable.Add(num2);
      }
    }
  }
}
