using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachCharactersMessage : NetworkMessage
  {
    public List<double> characters = new List<double>();
    public const uint Id = 6811;

    public override uint MessageId
    {
      get
      {
        return 6811;
      }
    }

    public BreachCharactersMessage()
    {
    }

    public BreachCharactersMessage(List<double> characters)
    {
      this.characters = characters;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.characters.Count);
      for (int index = 0; index < this.characters.Count; ++index)
      {
        if (this.characters[index] < 0.0 || this.characters[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.characters[index] + ") on element 1 (starting at 1) of characters.");
        writer.WriteVarLong((long) this.characters[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = (double) reader.ReadVarUhLong();
        if (num2 < 0.0 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of characters.");
        this.characters.Add(num2);
      }
    }
  }
}
