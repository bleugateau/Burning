using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TitlesAndOrnamentsListMessage : NetworkMessage
  {
    public List<uint> titles = new List<uint>();
    public List<uint> ornaments = new List<uint>();
    public const uint Id = 6367;
    public uint activeTitle;
    public uint activeOrnament;

    public override uint MessageId
    {
      get
      {
        return 6367;
      }
    }

    public TitlesAndOrnamentsListMessage()
    {
    }

    public TitlesAndOrnamentsListMessage(
      List<uint> titles,
      List<uint> ornaments,
      uint activeTitle,
      uint activeOrnament)
    {
      this.titles = titles;
      this.ornaments = ornaments;
      this.activeTitle = activeTitle;
      this.activeOrnament = activeOrnament;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.titles.Count);
      for (int index = 0; index < this.titles.Count; ++index)
      {
        if (this.titles[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.titles[index] + ") on element 1 (starting at 1) of titles.");
        writer.WriteVarShort((short) this.titles[index]);
      }
      writer.WriteShort((short) this.ornaments.Count);
      for (int index = 0; index < this.ornaments.Count; ++index)
      {
        if (this.ornaments[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.ornaments[index] + ") on element 2 (starting at 1) of ornaments.");
        writer.WriteVarShort((short) this.ornaments[index]);
      }
      if (this.activeTitle < 0U)
        throw new Exception("Forbidden value (" + (object) this.activeTitle + ") on element activeTitle.");
      writer.WriteVarShort((short) this.activeTitle);
      if (this.activeOrnament < 0U)
        throw new Exception("Forbidden value (" + (object) this.activeOrnament + ") on element activeOrnament.");
      writer.WriteVarShort((short) this.activeOrnament);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of titles.");
        this.titles.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ornaments.");
        this.ornaments.Add(num2);
      }
      this.activeTitle = (uint) reader.ReadVarUhShort();
      if (this.activeTitle < 0U)
        throw new Exception("Forbidden value (" + (object) this.activeTitle + ") on element of TitlesAndOrnamentsListMessage.activeTitle.");
      this.activeOrnament = (uint) reader.ReadVarUhShort();
      if (this.activeOrnament < 0U)
        throw new Exception("Forbidden value (" + (object) this.activeOrnament + ") on element of TitlesAndOrnamentsListMessage.activeOrnament.");
    }
  }
}
