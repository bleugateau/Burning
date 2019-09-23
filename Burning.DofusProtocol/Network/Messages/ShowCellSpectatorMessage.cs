using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShowCellSpectatorMessage : ShowCellMessage
  {
    public new const uint Id = 6158;
    public string playerName;

    public override uint MessageId
    {
      get
      {
        return 6158;
      }
    }

    public ShowCellSpectatorMessage()
    {
    }

    public ShowCellSpectatorMessage(double sourceId, uint cellId, string playerName)
      : base(sourceId, cellId)
    {
      this.playerName = playerName;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.playerName);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerName = reader.ReadUTF();
    }
  }
}
