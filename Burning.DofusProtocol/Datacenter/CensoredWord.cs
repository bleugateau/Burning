using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CensoredWords", true)]
  public class CensoredWord : IDataObject
  {
    public const string MODULE = "CensoredWords";
    public uint Id;
    public uint ListId;
    public string Language;
    public string Word;
    public bool DeepLooking;
  }
}
