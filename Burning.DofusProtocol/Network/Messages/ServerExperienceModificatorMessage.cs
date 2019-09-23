using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ServerExperienceModificatorMessage : NetworkMessage
  {
    public const uint Id = 6237;
    public uint experiencePercent;

    public override uint MessageId
    {
      get
      {
        return 6237;
      }
    }

    public ServerExperienceModificatorMessage()
    {
    }

    public ServerExperienceModificatorMessage(uint experiencePercent)
    {
      this.experiencePercent = experiencePercent;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.experiencePercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.experiencePercent + ") on element experiencePercent.");
      writer.WriteVarShort((short) this.experiencePercent);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.experiencePercent = (uint) reader.ReadVarUhShort();
      if (this.experiencePercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.experiencePercent + ") on element of ServerExperienceModificatorMessage.experiencePercent.");
    }
  }
}
