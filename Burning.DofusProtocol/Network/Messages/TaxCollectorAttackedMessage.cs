using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorAttackedMessage : NetworkMessage
  {
    public const uint Id = 5918;
    public uint firstNameId;
    public uint lastNameId;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;
    public BasicGuildInformations guild;

    public override uint MessageId
    {
      get
      {
        return 5918;
      }
    }

    public TaxCollectorAttackedMessage()
    {
    }

    public TaxCollectorAttackedMessage(
      uint firstNameId,
      uint lastNameId,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId,
      BasicGuildInformations guild)
    {
      this.firstNameId = firstNameId;
      this.lastNameId = lastNameId;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.guild = guild;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element firstNameId.");
      writer.WriteVarShort((short) this.firstNameId);
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element lastNameId.");
      writer.WriteVarShort((short) this.lastNameId);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      this.guild.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.firstNameId = (uint) reader.ReadVarUhShort();
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element of TaxCollectorAttackedMessage.firstNameId.");
      this.lastNameId = (uint) reader.ReadVarUhShort();
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element of TaxCollectorAttackedMessage.lastNameId.");
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of TaxCollectorAttackedMessage.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of TaxCollectorAttackedMessage.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of TaxCollectorAttackedMessage.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of TaxCollectorAttackedMessage.subAreaId.");
      this.guild = new BasicGuildInformations();
      this.guild.Deserialize(reader);
    }
  }
}
