using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class PlayerStatusExtended : PlayerStatus
  {
    public new const uint Id = 414;
    public string message;

    public override uint TypeId
    {
      get
      {
        return 414;
      }
    }

    public PlayerStatusExtended()
    {
    }

    public PlayerStatusExtended(uint statusId, string message)
      : base(statusId)
    {
      this.message = message;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.message);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.message = reader.ReadUTF();
    }
  }
}
