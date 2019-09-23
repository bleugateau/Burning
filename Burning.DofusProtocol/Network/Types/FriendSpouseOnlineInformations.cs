using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FriendSpouseOnlineInformations : FriendSpouseInformations
  {
    public new const uint Id = 93;
    public double mapId;
    public uint subAreaId;
    public bool inFight;
    public bool followSpouse;

    public override uint TypeId
    {
      get
      {
        return 93;
      }
    }

    public FriendSpouseOnlineInformations()
    {
    }

    public FriendSpouseOnlineInformations(
      uint spouseAccountId,
      double spouseId,
      string spouseName,
      uint spouseLevel,
      int breed,
      int sex,
      EntityLook spouseEntityLook,
      GuildInformations guildInfo,
      int alignmentSide,
      double mapId,
      uint subAreaId,
      bool inFight,
      bool followSpouse)
      : base(spouseAccountId, spouseId, spouseName, spouseLevel, breed, sex, spouseEntityLook, guildInfo, alignmentSide)
    {
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.inFight = inFight;
      this.followSpouse = followSpouse;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.inFight), (byte) 1, this.followSpouse);
      writer.WriteByte((byte) num);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.inFight = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.followSpouse = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of FriendSpouseOnlineInformations.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of FriendSpouseOnlineInformations.subAreaId.");
    }
  }
}
