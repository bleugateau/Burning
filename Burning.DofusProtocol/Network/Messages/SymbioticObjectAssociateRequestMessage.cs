using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SymbioticObjectAssociateRequestMessage : NetworkMessage
  {
    public const uint Id = 6522;
    public uint symbioteUID;
    public uint symbiotePos;
    public uint hostUID;
    public uint hostPos;

    public override uint MessageId
    {
      get
      {
        return 6522;
      }
    }

    public SymbioticObjectAssociateRequestMessage()
    {
    }

    public SymbioticObjectAssociateRequestMessage(
      uint symbioteUID,
      uint symbiotePos,
      uint hostUID,
      uint hostPos)
    {
      this.symbioteUID = symbioteUID;
      this.symbiotePos = symbiotePos;
      this.hostUID = hostUID;
      this.hostPos = hostPos;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.symbioteUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.symbioteUID + ") on element symbioteUID.");
      writer.WriteVarInt((int) this.symbioteUID);
      if (this.symbiotePos < 0U || this.symbiotePos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.symbiotePos + ") on element symbiotePos.");
      writer.WriteByte((byte) this.symbiotePos);
      if (this.hostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.hostUID + ") on element hostUID.");
      writer.WriteVarInt((int) this.hostUID);
      if (this.hostPos < 0U || this.hostPos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.hostPos + ") on element hostPos.");
      writer.WriteByte((byte) this.hostPos);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.symbioteUID = reader.ReadVarUhInt();
      if (this.symbioteUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.symbioteUID + ") on element of SymbioticObjectAssociateRequestMessage.symbioteUID.");
      this.symbiotePos = (uint) reader.ReadByte();
      if (this.symbiotePos < 0U || this.symbiotePos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.symbiotePos + ") on element of SymbioticObjectAssociateRequestMessage.symbiotePos.");
      this.hostUID = reader.ReadVarUhInt();
      if (this.hostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.hostUID + ") on element of SymbioticObjectAssociateRequestMessage.hostUID.");
      this.hostPos = (uint) reader.ReadByte();
      if (this.hostPos < 0U || this.hostPos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.hostPos + ") on element of SymbioticObjectAssociateRequestMessage.hostPos.");
    }
  }
}
