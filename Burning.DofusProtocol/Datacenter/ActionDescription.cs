using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ActionDescriptions", true)]
  public class ActionDescription : IDataObject
  {
    public const string MODULE = "ActionDescriptions";
    public uint Id;
    public uint TypeId;
    public string Name;
    public uint DescriptionId;
    public bool Trusted;
    public bool NeedInteraction;
    public uint MaxUsePerFrame;
    public uint MinimalUseInterval;
    public bool NeedConfirmation;
  }
}
