using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class Preset
  {
    public const uint Id = 355;
    public int id;

    public virtual uint TypeId
    {
      get
      {
        return 355;
      }
    }

    public Preset()
    {
    }

    public Preset(int id)
    {
      this.id = id;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.id);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (int) reader.ReadShort();
    }
  }
}
