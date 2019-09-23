using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
  {
    public new const uint Id = 5615;
    public uint maxPods;
    public uint prospecting;
    public uint wisdom;
    public uint taxCollectorsCount;
    public int taxCollectorAttack;
    public double kamas;
    public double experience;
    public uint pods;
    public double itemsValue;

    public override uint MessageId
    {
      get
      {
        return 5615;
      }
    }

    public TaxCollectorDialogQuestionExtendedMessage()
    {
    }

    public TaxCollectorDialogQuestionExtendedMessage(
      BasicGuildInformations guildInfo,
      uint maxPods,
      uint prospecting,
      uint wisdom,
      uint taxCollectorsCount,
      int taxCollectorAttack,
      double kamas,
      double experience,
      uint pods,
      double itemsValue)
      : base(guildInfo)
    {
      this.maxPods = maxPods;
      this.prospecting = prospecting;
      this.wisdom = wisdom;
      this.taxCollectorsCount = taxCollectorsCount;
      this.taxCollectorAttack = taxCollectorAttack;
      this.kamas = kamas;
      this.experience = experience;
      this.pods = pods;
      this.itemsValue = itemsValue;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.maxPods < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxPods + ") on element maxPods.");
      writer.WriteVarShort((short) this.maxPods);
      if (this.prospecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.prospecting + ") on element prospecting.");
      writer.WriteVarShort((short) this.prospecting);
      if (this.wisdom < 0U)
        throw new Exception("Forbidden value (" + (object) this.wisdom + ") on element wisdom.");
      writer.WriteVarShort((short) this.wisdom);
      if (this.taxCollectorsCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorsCount + ") on element taxCollectorsCount.");
      writer.WriteByte((byte) this.taxCollectorsCount);
      writer.WriteInt(this.taxCollectorAttack);
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element kamas.");
      writer.WriteVarLong((long) this.kamas);
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteVarLong((long) this.experience);
      if (this.pods < 0U)
        throw new Exception("Forbidden value (" + (object) this.pods + ") on element pods.");
      writer.WriteVarInt((int) this.pods);
      if (this.itemsValue < 0.0 || this.itemsValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.itemsValue + ") on element itemsValue.");
      writer.WriteVarLong((long) this.itemsValue);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.maxPods = (uint) reader.ReadVarUhShort();
      if (this.maxPods < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxPods + ") on element of TaxCollectorDialogQuestionExtendedMessage.maxPods.");
      this.prospecting = (uint) reader.ReadVarUhShort();
      if (this.prospecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.prospecting + ") on element of TaxCollectorDialogQuestionExtendedMessage.prospecting.");
      this.wisdom = (uint) reader.ReadVarUhShort();
      if (this.wisdom < 0U)
        throw new Exception("Forbidden value (" + (object) this.wisdom + ") on element of TaxCollectorDialogQuestionExtendedMessage.wisdom.");
      this.taxCollectorsCount = (uint) reader.ReadByte();
      if (this.taxCollectorsCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorsCount + ") on element of TaxCollectorDialogQuestionExtendedMessage.taxCollectorsCount.");
      this.taxCollectorAttack = reader.ReadInt();
      this.kamas = (double) reader.ReadVarUhLong();
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element of TaxCollectorDialogQuestionExtendedMessage.kamas.");
      this.experience = (double) reader.ReadVarUhLong();
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of TaxCollectorDialogQuestionExtendedMessage.experience.");
      this.pods = reader.ReadVarUhInt();
      if (this.pods < 0U)
        throw new Exception("Forbidden value (" + (object) this.pods + ") on element of TaxCollectorDialogQuestionExtendedMessage.pods.");
      this.itemsValue = (double) reader.ReadVarUhLong();
      if (this.itemsValue < 0.0 || this.itemsValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.itemsValue + ") on element of TaxCollectorDialogQuestionExtendedMessage.itemsValue.");
    }
  }
}
