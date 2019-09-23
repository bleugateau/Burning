using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemMinimalInformation : Item
  {
    public List<ObjectEffect> effects = new List<ObjectEffect>();
    public new const uint Id = 124;
    public uint objectGID;

    public override uint TypeId
    {
      get
      {
        return 124;
      }
    }

    public ObjectItemMinimalInformation()
    {
    }

    public ObjectItemMinimalInformation(uint objectGID, List<ObjectEffect> effects)
    {
      this.objectGID = objectGID;
      this.effects = effects;
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
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ObjectItemMinimalInformation.objectGID.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectEffect instance = ProtocolTypeManager.GetInstance<ObjectEffect>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.effects.Add(instance);
      }
    }
  }
}
