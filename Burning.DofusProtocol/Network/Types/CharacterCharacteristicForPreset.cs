using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterCharacteristicForPreset : SimpleCharacterCharacteristicForPreset
  {
    public new const uint Id = 539;
    public int stuff;

    public override uint TypeId
    {
      get
      {
        return 539;
      }
    }

    public CharacterCharacteristicForPreset()
    {
    }

    public CharacterCharacteristicForPreset(string keyword, int @base, int additionnal, int stuff)
      : base(keyword, @base, additionnal)
    {
      this.stuff = stuff;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteVarShort((short) this.stuff);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.stuff = (int) reader.ReadVarShort();
    }
  }
}
