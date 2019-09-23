using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareSubscribedMessage : NetworkMessage
  {
    public const uint Id = 6660;
    public double dareId;
    public bool success;
    public bool subscribe;
    public DareVersatileInformations dareVersatilesInfos;

    public override uint MessageId
    {
      get
      {
        return 6660;
      }
    }

    public DareSubscribedMessage()
    {
    }

    public DareSubscribedMessage(
      double dareId,
      bool success,
      bool subscribe,
      DareVersatileInformations dareVersatilesInfos)
    {
      this.dareId = dareId;
      this.success = success;
      this.subscribe = subscribe;
      this.dareVersatilesInfos = dareVersatilesInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.success), (byte) 1, this.subscribe);
      writer.WriteByte((byte) num);
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element dareId.");
      writer.WriteDouble(this.dareId);
      this.dareVersatilesInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadByte();
      this.success = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.subscribe = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.dareId = reader.ReadDouble();
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element of DareSubscribedMessage.dareId.");
      this.dareVersatilesInfos = new DareVersatileInformations();
      this.dareVersatilesInfos.Deserialize(reader);
    }
  }
}
