using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class InteractiveElement
  {
    public List<InteractiveElementSkill> enabledSkills = new List<InteractiveElementSkill>();
    public List<InteractiveElementSkill> disabledSkills = new List<InteractiveElementSkill>();
    public const uint Id = 80;
    public uint elementId;
    public int elementTypeId;
    public bool onCurrentMap;

    public virtual uint TypeId
    {
      get
      {
        return 80;
      }
    }

    public InteractiveElement()
    {
    }

    public InteractiveElement(
      uint elementId,
      int elementTypeId,
      List<InteractiveElementSkill> enabledSkills,
      List<InteractiveElementSkill> disabledSkills,
      bool onCurrentMap)
    {
      this.elementId = elementId;
      this.elementTypeId = elementTypeId;
      this.enabledSkills = enabledSkills;
      this.disabledSkills = disabledSkills;
      this.onCurrentMap = onCurrentMap;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element elementId.");
      writer.WriteInt((int) this.elementId);
      writer.WriteInt(this.elementTypeId);
      writer.WriteShort((short) this.enabledSkills.Count);
      for (int index = 0; index < this.enabledSkills.Count; ++index)
      {
        writer.WriteShort((short) this.enabledSkills[index].TypeId);
        this.enabledSkills[index].Serialize(writer);
      }
      writer.WriteShort((short) this.disabledSkills.Count);
      for (int index = 0; index < this.disabledSkills.Count; ++index)
      {
        writer.WriteShort((short) this.disabledSkills[index].TypeId);
        this.disabledSkills[index].Serialize(writer);
      }
      writer.WriteBoolean(this.onCurrentMap);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.elementId = (uint) reader.ReadInt();
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element of InteractiveElement.elementId.");
      this.elementTypeId = reader.ReadInt();
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        InteractiveElementSkill instance = ProtocolTypeManager.GetInstance<InteractiveElementSkill>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.enabledSkills.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        InteractiveElementSkill instance = ProtocolTypeManager.GetInstance<InteractiveElementSkill>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.disabledSkills.Add(instance);
      }
      this.onCurrentMap = reader.ReadBoolean();
    }
  }
}
