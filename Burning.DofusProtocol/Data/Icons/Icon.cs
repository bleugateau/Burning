using System.Drawing;
using System.IO;

namespace Burning.DofusProtocol.Data.Icons
{
  public class Icon
  {
    public Icon(int id, string name, byte[] data)
    {
      this.Id = id;
      this.Name = name;
      this.Image = (Image) new Bitmap(Image.FromStream((Stream) new MemoryStream(data)), new Size(32, 32));
    }

    public int Id { get; }

    public string Name { get; }

    public Image Image { get; }
  }
}
