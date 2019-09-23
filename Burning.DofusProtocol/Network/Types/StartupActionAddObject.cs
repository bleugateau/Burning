using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class StartupActionAddObject
  {
    public List<ObjectItemInformationWithQuantity> items = new List<ObjectItemInformationWithQuantity>();
    public const uint Id = 52;
    public uint uid;
    public string title;
    public string text;
    public string descUrl;
    public string pictureUrl;

    public virtual uint TypeId
    {
      get
      {
        return 52;
      }
    }

    public StartupActionAddObject()
    {
    }

    public StartupActionAddObject(
      uint uid,
      string title,
      string text,
      string descUrl,
      string pictureUrl,
      List<ObjectItemInformationWithQuantity> items)
    {
      this.uid = uid;
      this.title = title;
      this.text = text;
      this.descUrl = descUrl;
      this.pictureUrl = pictureUrl;
      this.items = items;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element uid.");
      writer.WriteInt((int) this.uid);
      writer.WriteUTF(this.title);
      writer.WriteUTF(this.text);
      writer.WriteUTF(this.descUrl);
      writer.WriteUTF(this.pictureUrl);
      writer.WriteShort((short) this.items.Count);
      for (int index = 0; index < this.items.Count; ++index)
        this.items[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.uid = (uint) reader.ReadInt();
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element of StartupActionAddObject.uid.");
      this.title = reader.ReadUTF();
      this.text = reader.ReadUTF();
      this.descUrl = reader.ReadUTF();
      this.pictureUrl = reader.ReadUTF();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemInformationWithQuantity informationWithQuantity = new ObjectItemInformationWithQuantity();
        informationWithQuantity.Deserialize(reader);
        this.items.Add(informationWithQuantity);
      }
    }
  }
}
