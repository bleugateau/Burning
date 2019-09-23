using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementDetailedListRequestMessage : NetworkMessage
  {
    public const uint Id = 6357;
    public uint categoryId;

    public override uint MessageId
    {
      get
      {
        return 6357;
      }
    }

    public AchievementDetailedListRequestMessage()
    {
    }

    public AchievementDetailedListRequestMessage(uint categoryId)
    {
      this.categoryId = categoryId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.categoryId < 0U)
        throw new Exception("Forbidden value (" + (object) this.categoryId + ") on element categoryId.");
      writer.WriteVarShort((short) this.categoryId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.categoryId = (uint) reader.ReadVarUhShort();
      if (this.categoryId < 0U)
        throw new Exception("Forbidden value (" + (object) this.categoryId + ") on element of AchievementDetailedListRequestMessage.categoryId.");
    }
  }
}
