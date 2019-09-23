using System;

namespace Burning.DofusProtocol.Network
{
  public static class BooleanByteWrapper
  {
    public static bool GetFlag(byte flag, byte offset)
    {
      if (offset >= (byte) 8)
        throw new ArgumentException("offset must be lesser than 8");
      return ((uint) flag & (uint) (byte) (1 << (int) offset)) > 0U;
    }

    public static byte SetFlag(byte flag, byte offset, bool value)
    {
      if (offset >= (byte) 8)
        throw new ArgumentException("offset must be lesser than 8");
      if (!value)
        return (byte) ((uint) flag & (uint) ((int) byte.MaxValue - (1 << (int) offset)));
      return (byte) ((uint) flag | 1U << (int) offset);
    }

    public static byte SetFlag(int flag, byte offset, bool value)
    {
      if (offset >= (byte) 8)
        throw new ArgumentException("offset must be lesser than 8");
      if (!value)
        return (byte) (flag & (int) byte.MaxValue - (1 << (int) offset));
      return (byte) (flag | 1 << (int) offset);
    }
  }
}
