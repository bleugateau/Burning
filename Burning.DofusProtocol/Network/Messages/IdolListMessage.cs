using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdolListMessage : NetworkMessage
  {
    public List<uint> chosenIdols = new List<uint>();
    public List<uint> partyChosenIdols = new List<uint>();
    public List<PartyIdol> partyIdols = new List<PartyIdol>();
    public const uint Id = 6585;

    public override uint MessageId
    {
      get
      {
        return 6585;
      }
    }

    public IdolListMessage()
    {
    }

    public IdolListMessage(
      List<uint> chosenIdols,
      List<uint> partyChosenIdols,
      List<PartyIdol> partyIdols)
    {
      this.chosenIdols = chosenIdols;
      this.partyChosenIdols = partyChosenIdols;
      this.partyIdols = partyIdols;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.chosenIdols.Count);
      for (int index = 0; index < this.chosenIdols.Count; ++index)
      {
        if (this.chosenIdols[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.chosenIdols[index] + ") on element 1 (starting at 1) of chosenIdols.");
        writer.WriteVarShort((short) this.chosenIdols[index]);
      }
      writer.WriteShort((short) this.partyChosenIdols.Count);
      for (int index = 0; index < this.partyChosenIdols.Count; ++index)
      {
        if (this.partyChosenIdols[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.partyChosenIdols[index] + ") on element 2 (starting at 1) of partyChosenIdols.");
        writer.WriteVarShort((short) this.partyChosenIdols[index]);
      }
      writer.WriteShort((short) this.partyIdols.Count);
      for (int index = 0; index < this.partyIdols.Count; ++index)
      {
        writer.WriteShort((short) this.partyIdols[index].TypeId);
        this.partyIdols[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of chosenIdols.");
        this.chosenIdols.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of partyChosenIdols.");
        this.partyChosenIdols.Add(num2);
      }
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        PartyIdol instance = ProtocolTypeManager.GetInstance<PartyIdol>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.partyIdols.Add(instance);
      }
    }
  }
}
