using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemNotInContainer : Item
  {
    public List<ObjectEffect> effects = new List<ObjectEffect>();
    public new const uint Id = 134;
    public uint objectGID;
    public uint objectUID;
    public uint quantity;

    public override uint TypeId
    {
      get
      {
        return 134;
      }
    }

    public ObjectItemNotInContainer()
    {
    }

    public ObjectItemNotInContainer(
      uint objectGID,
      List<ObjectEffect> effects,
      uint objectUID,
      uint quantity)
    {
      this.objectGID = objectGID;
      this.effects = effects;
      this.objectUID = objectUID;
      this.quantity = quantity;
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
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ObjectItemNotInContainer.objectGID.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectEffect instance = ProtocolTypeManager.GetInstance<ObjectEffect>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.effects.Add(instance);
      }
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectItemNotInContainer.objectUID.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectItemNotInContainer.quantity.");
    }
  }
}
