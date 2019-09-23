using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightOptionsInformations
  {
    public const uint Id = 20;
    public bool isSecret;
    public bool isRestrictedToPartyOnly;
    public bool isClosed;
    public bool isAskingForHelp;

    public virtual uint TypeId
    {
      get
      {
        return 20;
      }
    }

    public FightOptionsInformations()
    {
    }

    public FightOptionsInformations(
      bool isSecret,
      bool isRestrictedToPartyOnly,
      bool isClosed,
      bool isAskingForHelp)
    {
      this.isSecret = isSecret;
      this.isRestrictedToPartyOnly = isRestrictedToPartyOnly;
      this.isClosed = isClosed;
      this.isAskingForHelp = isAskingForHelp;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.isSecret), (byte) 1, this.isRestrictedToPartyOnly), (byte) 2, this.isClosed), (byte) 3, this.isAskingForHelp);
      writer.WriteByte((byte) num);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.isSecret = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.isRestrictedToPartyOnly = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.isClosed = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 2);
      this.isAskingForHelp = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 3);
    }
  }
}
