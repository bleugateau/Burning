using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HavenBagFurnituresRequestMessage : NetworkMessage
  {
    public List<uint> cellIds = new List<uint>();
    public List<int> funitureIds = new List<int>();
    public List<uint> orientations = new List<uint>();
    public const uint Id = 6637;

    public override uint MessageId
    {
      get
      {
        return 6637;
      }
    }

    public HavenBagFurnituresRequestMessage()
    {
    }

    public HavenBagFurnituresRequestMessage(
      List<uint> cellIds,
      List<int> funitureIds,
      List<uint> orientations)
    {
      this.cellIds = cellIds;
      this.funitureIds = funitureIds;
      this.orientations = orientations;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.cellIds.Count);
      for (int index = 0; index < this.cellIds.Count; ++index)
      {
        if (this.cellIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.cellIds[index] + ") on element 1 (starting at 1) of cellIds.");
        writer.WriteVarShort((short) this.cellIds[index]);
      }
      writer.WriteShort((short) this.funitureIds.Count);
      for (int index = 0; index < this.funitureIds.Count; ++index)
        writer.WriteInt(this.funitureIds[index]);
      writer.WriteShort((short) this.orientations.Count);
      for (int index = 0; index < this.orientations.Count; ++index)
      {
        if (this.orientations[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.orientations[index] + ") on element 3 (starting at 1) of orientations.");
        writer.WriteByte((byte) this.orientations[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of cellIds.");
        this.cellIds.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
        this.funitureIds.Add(reader.ReadInt());
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of orientations.");
        this.orientations.Add(num2);
      }
    }
  }
}
