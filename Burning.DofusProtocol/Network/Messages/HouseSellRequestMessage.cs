using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseSellRequestMessage : NetworkMessage
  {
    public const uint Id = 5697;
    public uint instanceId;
    public double amount;
    public bool forSale;

    public override uint MessageId
    {
      get
      {
        return 5697;
      }
    }

    public HouseSellRequestMessage()
    {
    }

    public HouseSellRequestMessage(uint instanceId, double amount, bool forSale)
    {
      this.instanceId = instanceId;
      this.amount = amount;
      this.forSale = forSale;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      if (this.amount < 0.0 || this.amount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.amount + ") on element amount.");
      writer.WriteVarLong((long) this.amount);
      writer.WriteBoolean(this.forSale);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseSellRequestMessage.instanceId.");
      this.amount = (double) reader.ReadVarUhLong();
      if (this.amount < 0.0 || this.amount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.amount + ") on element of HouseSellRequestMessage.amount.");
      this.forSale = reader.ReadBoolean();
    }
  }
}
