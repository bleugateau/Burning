using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SetUpdateMessage : NetworkMessage
  {
    public List<uint> setObjects = new List<uint>();
    public List<ObjectEffect> setEffects = new List<ObjectEffect>();
    public const uint Id = 5503;
    public uint setId;

    public override uint MessageId
    {
      get
      {
        return 5503;
      }
    }

    public SetUpdateMessage()
    {
    }

    public SetUpdateMessage(uint setId, List<uint> setObjects, List<ObjectEffect> setEffects)
    {
      this.setId = setId;
      this.setObjects = setObjects;
      this.setEffects = setEffects;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.setId < 0U)
        throw new Exception("Forbidden value (" + (object) this.setId + ") on element setId.");
      writer.WriteVarShort((short) this.setId);
      writer.WriteShort((short) this.setObjects.Count);
      for (int index = 0; index < this.setObjects.Count; ++index)
      {
        if (this.setObjects[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.setObjects[index] + ") on element 2 (starting at 1) of setObjects.");
        writer.WriteVarShort((short) this.setObjects[index]);
      }
      writer.WriteShort((short) this.setEffects.Count);
      for (int index = 0; index < this.setEffects.Count; ++index)
      {
        writer.WriteShort((short) this.setEffects[index].TypeId);
        this.setEffects[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.setId = (uint) reader.ReadVarUhShort();
      if (this.setId < 0U)
        throw new Exception("Forbidden value (" + (object) this.setId + ") on element of SetUpdateMessage.setId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of setObjects.");
        this.setObjects.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        ObjectEffect instance = ProtocolTypeManager.GetInstance<ObjectEffect>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.setEffects.Add(instance);
      }
    }
  }
}
