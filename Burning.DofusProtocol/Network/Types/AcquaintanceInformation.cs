using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AcquaintanceInformation : AbstractContactInformations
  {
    public new const uint Id = 561;
    public uint playerState;

    public override uint TypeId
    {
      get
      {
        return 561;
      }
    }

    public AcquaintanceInformation()
    {
    }

    public AcquaintanceInformation(uint accountId, string accountName, uint playerState)
      : base(accountId, accountName)
    {
      this.playerState = playerState;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.playerState);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerState = (uint) reader.ReadByte();
      if (this.playerState < 0U)
        throw new Exception("Forbidden value (" + (object) this.playerState + ") on element of AcquaintanceInformation.playerState.");
    }
  }
}
