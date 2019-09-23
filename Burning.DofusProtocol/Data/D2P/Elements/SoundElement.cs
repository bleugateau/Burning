using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Data.D2P.Elements
{
  public class SoundElement : BasicElement
  {
    public int SoundId { get; set; }

    public int MinDelayBetweenLoops { get; set; }

    public int MaxDelayBetweenLoops { get; set; }

    public int BaseVolume { get; set; }

    public int FullVolumeDistance { get; set; }

    public int NullVolumeDistance { get; set; }

    public SoundElement(Cell param1)
      : base(param1)
    {
    }

    public override int ElementType
    {
      get
      {
        return 33;
      }
    }

    public override void FromRaw(BigEndianReader param1, int param2)
    {
      BigEndianReader bigEndianReader = param1;
      try
      {
        this.SoundId = bigEndianReader.ReadInt();
        this.BaseVolume = (int) bigEndianReader.ReadShort();
        this.FullVolumeDistance = bigEndianReader.ReadInt();
        this.NullVolumeDistance = bigEndianReader.ReadInt();
        this.MinDelayBetweenLoops = (int) bigEndianReader.ReadShort();
        this.MaxDelayBetweenLoops = (int) bigEndianReader.ReadShort();
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
        throw;
      }
    }
  }
}
