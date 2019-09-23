using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
  {
    public new const uint Id = 6460;
    public uint foodUID;
    public uint foodPos;
    public bool preview;

    public override uint MessageId
    {
      get
      {
        return 6460;
      }
    }

    public MimicryObjectFeedAndAssociateRequestMessage()
    {
    }

    public MimicryObjectFeedAndAssociateRequestMessage(
      uint symbioteUID,
      uint symbiotePos,
      uint hostUID,
      uint hostPos,
      uint foodUID,
      uint foodPos,
      bool preview)
      : base(symbioteUID, symbiotePos, hostUID, hostPos)
    {
      this.foodUID = foodUID;
      this.foodPos = foodPos;
      this.preview = preview;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.foodUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.foodUID + ") on element foodUID.");
      writer.WriteVarInt((int) this.foodUID);
      if (this.foodPos < 0U || this.foodPos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.foodPos + ") on element foodPos.");
      writer.WriteByte((byte) this.foodPos);
      writer.WriteBoolean(this.preview);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.foodUID = reader.ReadVarUhInt();
      if (this.foodUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.foodUID + ") on element of MimicryObjectFeedAndAssociateRequestMessage.foodUID.");
      this.foodPos = (uint) reader.ReadByte();
      if (this.foodPos < 0U || this.foodPos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.foodPos + ") on element of MimicryObjectFeedAndAssociateRequestMessage.foodPos.");
      this.preview = reader.ReadBoolean();
    }
  }
}
