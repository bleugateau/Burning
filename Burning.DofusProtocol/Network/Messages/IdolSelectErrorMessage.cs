using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdolSelectErrorMessage : NetworkMessage
  {
    public const uint Id = 6584;
    public uint reason;
    public uint idolId;
    public bool activate;
    public bool party;

    public override uint MessageId
    {
      get
      {
        return 6584;
      }
    }

    public IdolSelectErrorMessage()
    {
    }

    public IdolSelectErrorMessage(uint reason, uint idolId, bool activate, bool party)
    {
      this.reason = reason;
      this.idolId = idolId;
      this.activate = activate;
      this.party = party;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.activate), (byte) 1, this.party);
      writer.WriteByte((byte) num);
      writer.WriteByte((byte) this.reason);
      if (this.idolId < 0U)
        throw new Exception("Forbidden value (" + (object) this.idolId + ") on element idolId.");
      writer.WriteVarShort((short) this.idolId);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.activate = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.party = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.reason = (uint) reader.ReadByte();
      if (this.reason < 0U)
        throw new Exception("Forbidden value (" + (object) this.reason + ") on element of IdolSelectErrorMessage.reason.");
      this.idolId = (uint) reader.ReadVarUhShort();
      if (this.idolId < 0U)
        throw new Exception("Forbidden value (" + (object) this.idolId + ") on element of IdolSelectErrorMessage.idolId.");
    }
  }
}
