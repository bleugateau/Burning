using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemToSell : Item
  {
    public List<ObjectEffect> effects = new List<ObjectEffect>();
    public new const uint Id = 120;
    public uint objectGID;
    public uint objectUID;
    public uint quantity;
    public double objectPrice;

    public override uint TypeId
    {
      get
      {
        return 120;
      }
    }

    public ObjectItemToSell()
    {
    }

    public ObjectItemToSell(
      uint objectGID,
      List<ObjectEffect> effects,
      uint objectUID,
      uint quantity,
      double objectPrice)
    {
      this.objectGID = objectGID;
      this.effects = effects;
      this.objectUID = objectUID;
      this.quantity = quantity;
      this.objectPrice = objectPrice;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
      writer.WriteShort((short) this.effects.Count);
      for (int index = 0; index < this.effects.Count; ++index)
      {
        writer.WriteShort((short) this.effects[index].TypeId);
        this.effects[index].Serialize(writer);
      }
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
      if (this.objectPrice < 0.0 || this.objectPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectPrice + ") on element objectPrice.");
      writer.WriteVarLong((long) this.objectPrice);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ObjectItemToSell.objectGID.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectEffect instance = ProtocolTypeManager.GetInstance<ObjectEffect>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.effects.Add(instance);
      }
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectItemToSell.objectUID.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectItemToSell.quantity.");
      this.objectPrice = (double) reader.ReadVarUhLong();
      if (this.objectPrice < 0.0 || this.objectPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectPrice + ") on element of ObjectItemToSell.objectPrice.");
    }
  }
}
