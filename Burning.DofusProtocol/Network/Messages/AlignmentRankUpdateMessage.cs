using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AlignmentRankUpdateMessage : NetworkMessage
  {
    public const uint Id = 6058;
    public uint alignmentRank;
    public bool verbose;

    public override uint MessageId
    {
      get
      {
        return 6058;
      }
    }

    public AlignmentRankUpdateMessage()
    {
    }

    public AlignmentRankUpdateMessage(uint alignmentRank, bool verbose)
    {
      this.alignmentRank = alignmentRank;
      this.verbose = verbose;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.alignmentRank < 0U)
        throw new Exception("Forbidden value (" + (object) this.alignmentRank + ") on element alignmentRank.");
      writer.WriteByte((byte) this.alignmentRank);
      writer.WriteBoolean(this.verbose);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.alignmentRank = (uint) reader.ReadByte();
      if (this.alignmentRank < 0U)
        throw new Exception("Forbidden value (" + (object) this.alignmentRank + ") on element of AlignmentRankUpdateMessage.alignmentRank.");
      this.verbose = reader.ReadBoolean();
    }
  }
}
