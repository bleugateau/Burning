using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyGuestInformations
  {
    public List<PartyEntityBaseInformation> entities = new List<PartyEntityBaseInformation>();
    public const uint Id = 374;
    public double guestId;
    public double hostId;
    public string name;
    public EntityLook guestLook;
    public int breed;
    public bool sex;
    public PlayerStatus status;

    public virtual uint TypeId
    {
      get
      {
        return 374;
      }
    }

    public PartyGuestInformations()
    {
    }

    public PartyGuestInformations(
      double guestId,
      double hostId,
      string name,
      EntityLook guestLook,
      int breed,
      bool sex,
      PlayerStatus status,
      List<PartyEntityBaseInformation> entities)
    {
      this.guestId = guestId;
      this.hostId = hostId;
      this.name = name;
      this.guestLook = guestLook;
      this.breed = breed;
      this.sex = sex;
      this.status = status;
      this.entities = entities;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element guestId.");
      writer.WriteVarLong((long) this.guestId);
      if (this.hostId < 0.0 || this.hostId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.hostId + ") on element hostId.");
      writer.WriteVarLong((long) this.hostId);
      writer.WriteUTF(this.name);
      this.guestLook.Serialize(writer);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
      writer.WriteShort((short) this.entities.Count);
      for (int index = 0; index < this.entities.Count; ++index)
        this.entities[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.guestId = (double) reader.ReadVarUhLong();
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element of PartyGuestInformations.guestId.");
      this.hostId = (double) reader.ReadVarUhLong();
      if (this.hostId < 0.0 || this.hostId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.hostId + ") on element of PartyGuestInformations.hostId.");
      this.name = reader.ReadUTF();
      this.guestLook = new EntityLook();
      this.guestLook.Deserialize(reader);
      this.breed = (int) reader.ReadByte();
      this.sex = reader.ReadBoolean();
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PartyEntityBaseInformation entityBaseInformation = new PartyEntityBaseInformation();
        entityBaseInformation.Deserialize(reader);
        this.entities.Add(entityBaseInformation);
      }
    }
  }
}
