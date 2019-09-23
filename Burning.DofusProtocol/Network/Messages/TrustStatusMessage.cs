using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TrustStatusMessage : NetworkMessage
  {
    public const uint Id = 6267;
    public bool trusted;
    public bool certified;

    public override uint MessageId
    {
      get
      {
        return 6267;
      }
    }

    public TrustStatusMessage()
    {
    }

    public TrustStatusMessage(bool trusted, bool certified)
    {
      this.trusted = trusted;
      this.certified = certified;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.trusted), (byte) 1, this.certified);
      writer.WriteByte((byte) num);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.trusted = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.certified = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
    }
  }
}
