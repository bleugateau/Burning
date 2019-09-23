using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SelectedServerDataMessage : NetworkMessage
  {
    public List<uint> ports = new List<uint>();
    public List<int> ticket = new List<int>();
    public const uint Id = 42;
    public uint serverId;
    public string address;
    public bool canCreateNewCharacter;

    public override uint MessageId
    {
      get
      {
        return 42;
      }
    }

    public SelectedServerDataMessage()
    {
    }

    public SelectedServerDataMessage(
      uint serverId,
      string address,
      List<uint> ports,
      bool canCreateNewCharacter,
      List<int> ticket)
    {
      this.serverId = serverId;
      this.address = address;
      this.ports = ports;
      this.canCreateNewCharacter = canCreateNewCharacter;
      this.ticket = ticket;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.serverId < 0U)
        throw new Exception("Forbidden value (" + (object) this.serverId + ") on element serverId.");
      writer.WriteVarShort((short) this.serverId);
      writer.WriteUTF(this.address);
      writer.WriteShort((short) this.ports.Count);
      for (int index = 0; index < this.ports.Count; ++index)
      {
        if (this.ports[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.ports[index] + ") on element 3 (starting at 1) of ports.");
        writer.WriteInt((int) this.ports[index]);
      }
      writer.WriteBoolean(this.canCreateNewCharacter);
      writer.WriteVarInt(this.ticket.Count);
      for (int index = 0; index < this.ticket.Count; ++index)
        writer.WriteByte((byte) this.ticket[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.serverId = (uint) reader.ReadVarUhShort();
      if (this.serverId < 0U)
        throw new Exception("Forbidden value (" + (object) this.serverId + ") on element of SelectedServerDataMessage.serverId.");
      this.address = reader.ReadUTF();
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ports.");
        this.ports.Add(num2);
      }
      this.canCreateNewCharacter = reader.ReadBoolean();
      uint num3 = (uint) reader.ReadVarInt();
      for (int index = 0; (long) index < (long) num3; ++index)
        this.ticket.Add((int) reader.ReadByte());
    }
  }
}
