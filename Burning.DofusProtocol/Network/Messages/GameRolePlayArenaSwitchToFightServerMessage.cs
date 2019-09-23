using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaSwitchToFightServerMessage : NetworkMessage
  {
    public List<uint> ports = new List<uint>();
    public List<int> ticket = new List<int>();
    public const uint Id = 6575;
    public string address;

    public override uint MessageId
    {
      get
      {
        return 6575;
      }
    }

    public GameRolePlayArenaSwitchToFightServerMessage()
    {
    }

    public GameRolePlayArenaSwitchToFightServerMessage(
      string address,
      List<uint> ports,
      List<int> ticket)
    {
      this.address = address;
      this.ports = ports;
      this.ticket = ticket;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.address);
      writer.WriteShort((short) this.ports.Count);
      for (int index = 0; index < this.ports.Count; ++index)
      {
        if (this.ports[index] < 0U || this.ports[index] > (uint) ushort.MaxValue)
          throw new Exception("Forbidden value (" + (object) this.ports[index] + ") on element 2 (starting at 1) of ports.");
        writer.WriteShort((short) this.ports[index]);
      }
      writer.WriteVarInt(this.ticket.Count);
      for (int index = 0; index < this.ticket.Count; ++index)
        writer.WriteByte((byte) this.ticket[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.address = reader.ReadUTF();
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadUShort();
        if (num2 < 0U || num2 > (uint) ushort.MaxValue)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ports.");
        this.ports.Add(num2);
      }
      uint num3 = (uint) reader.ReadVarInt();
      for (int index = 0; (long) index < (long) num3; ++index)
        this.ticket.Add((int) reader.ReadByte());
    }
  }
}
