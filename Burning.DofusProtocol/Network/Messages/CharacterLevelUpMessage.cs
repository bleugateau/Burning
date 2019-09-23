using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterLevelUpMessage : NetworkMessage
  {
    public const uint Id = 5670;
    public uint newLevel;

    public override uint MessageId
    {
      get
      {
        return 5670;
      }
    }

    public CharacterLevelUpMessage()
    {
    }

    public CharacterLevelUpMessage(uint newLevel)
    {
      this.newLevel = newLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.newLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.newLevel + ") on element newLevel.");
      writer.WriteVarShort((short) this.newLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.newLevel = (uint) reader.ReadVarUhShort();
      if (this.newLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.newLevel + ") on element of CharacterLevelUpMessage.newLevel.");
    }
  }
}
