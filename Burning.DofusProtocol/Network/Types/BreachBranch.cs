using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class BreachBranch
  {
    public List<MonsterInGroupLightInformations> bosses = new List<MonsterInGroupLightInformations>();
    public const uint Id = 558;
    public uint room;
    public uint element;
    public double map;

    public virtual uint TypeId
    {
      get
      {
        return 558;
      }
    }

    public BreachBranch()
    {
    }

    public BreachBranch(
      uint room,
      uint element,
      List<MonsterInGroupLightInformations> bosses,
      double map)
    {
      this.room = room;
      this.element = element;
      this.bosses = bosses;
      this.map = map;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.room < 0U)
        throw new Exception("Forbidden value (" + (object) this.room + ") on element room.");
      writer.WriteByte((byte) this.room);
      if (this.element < 0U)
        throw new Exception("Forbidden value (" + (object) this.element + ") on element element.");
      writer.WriteInt((int) this.element);
      writer.WriteShort((short) this.bosses.Count);
      for (int index = 0; index < this.bosses.Count; ++index)
        this.bosses[index].Serialize(writer);
      if (this.map < 0.0 || this.map > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.map + ") on element map.");
      writer.WriteDouble(this.map);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.room = (uint) reader.ReadByte();
      if (this.room < 0U)
        throw new Exception("Forbidden value (" + (object) this.room + ") on element of BreachBranch.room.");
      this.element = (uint) reader.ReadInt();
      if (this.element < 0U)
        throw new Exception("Forbidden value (" + (object) this.element + ") on element of BreachBranch.element.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MonsterInGroupLightInformations lightInformations = new MonsterInGroupLightInformations();
        lightInformations.Deserialize(reader);
        this.bosses.Add(lightInformations);
      }
      this.map = reader.ReadDouble();
      if (this.map < 0.0 || this.map > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.map + ") on element of BreachBranch.map.");
    }
  }
}
