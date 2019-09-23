using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class InteractiveElementWithAgeBonus : InteractiveElement
  {
    public new const uint Id = 398;
    public int ageBonus;

    public override uint TypeId
    {
      get
      {
        return 398;
      }
    }

    public InteractiveElementWithAgeBonus()
    {
    }

    public InteractiveElementWithAgeBonus(
      uint elementId,
      int elementTypeId,
      List<InteractiveElementSkill> enabledSkills,
      List<InteractiveElementSkill> disabledSkills,
      bool onCurrentMap,
      int ageBonus)
      : base(elementId, elementTypeId, enabledSkills, disabledSkills, onCurrentMap)
    {
      this.ageBonus = ageBonus;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.ageBonus < -1 || this.ageBonus > 1000)
        throw new Exception("Forbidden value (" + (object) this.ageBonus + ") on element ageBonus.");
      writer.WriteShort((short) this.ageBonus);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.ageBonus = (int) reader.ReadShort();
      if (this.ageBonus < -1 || this.ageBonus > 1000)
        throw new Exception("Forbidden value (" + (object) this.ageBonus + ") on element of InteractiveElementWithAgeBonus.ageBonus.");
    }
  }
}
