//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: AcquiredMethodTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"AcquiredMethodTable")]
  public partial class AcquiredMethodTable : global::ProtoBuf.IExtensible
  {
    public AcquiredMethodTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private string _Name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"Name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Name
    {
      get { return _Name; }
      set { _Name = value; }
    }
    private string _ActionDesc;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"ActionDesc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ActionDesc
    {
      get { return _ActionDesc; }
      set { _ActionDesc = value; }
    }
    private int _IsLink;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"IsLink", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int IsLink
    {
      get { return _IsLink; }
      set { _IsLink = value; }
    }
    private int _FuncitonID;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"FuncitonID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int FuncitonID
    {
      get { return _FuncitonID; }
      set { _FuncitonID = value; }
    }
    private string _ProbilityDesc;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"ProbilityDesc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ProbilityDesc
    {
      get { return _ProbilityDesc; }
      set { _ProbilityDesc = value; }
    }
    private string _LinkInfo;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"LinkInfo", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string LinkInfo
    {
      get { return _LinkInfo; }
      set { _LinkInfo = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _ReLinks = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(8, Name=@"ReLinks", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public global::System.Collections.Generic.List<int> ReLinks
    {
      get { return _ReLinks; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}