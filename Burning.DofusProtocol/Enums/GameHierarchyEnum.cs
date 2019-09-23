namespace Burning.DofusProtocol.Enums
{
  public enum GameHierarchyEnum
  {
    UNAVAILABLE = -1, // 0xFFFFFFFF
    PLAYER = 0,
    MODERATOR = 10, // 0x0000000A
    GAMEMASTER_PADAWAN = 20, // 0x00000014
    GAMEMASTER = 30, // 0x0000001E
    ADMIN = 40, // 0x00000028
  }
}
