using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanInformations
  {
    public const uint Id = 157;
    public ActorRestrictionsInformations restrictions;
    public bool sex;
    public HumanOption[] options;

    public virtual uint TypeId
    {
      get
      {
        return 157;
      }
    }

    public HumanInformations()
    {
    }

    public virtual void Serialize(IDataWriter writer)
    {
      this.restrictions.Serialize(writer);
      writer.WriteBoolean(this.sex);
      writer.WriteShort((short) this.options.Length);
      foreach (HumanOption option in this.options)
      {
        writer.WriteShort((short) option.TypeId);
        option.Serialize(writer);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.restrictions = new ActorRestrictionsInformations();
      this.restrictions.Deserialize(reader);
      this.sex = reader.ReadBoolean();
      int length = (int) reader.ReadShort();
      this.options = new HumanOption[length];
      for (int index = 0; index < length; ++index)
      {
        this.options[index] = ProtocolTypeManager.GetInstance<HumanOption>((ushort) reader.ReadShort());
        this.options[index].Deserialize(reader);
      }
    }

    public HumanInformations(
      ActorRestrictionsInformations restrictions,
      bool sex,
      HumanOption[] options)
    {
      this.restrictions = restrictions;
      this.sex = sex;
      this.options = options;
    }
  }
}
