//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: SwitchClientFunctionTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SwitchClientFunctionTable")]
  public partial class SwitchClientFunctionTable : global::ProtoBuf.IExtensible
  {
    public SwitchClientFunctionTable() {}
    
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
    private bool _Open;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"Open", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool Open
    {
      get { return _Open; }
      set { _Open = value; }
    }
    private string _DescA;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"DescA", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string DescA
    {
      get { return _DescA; }
      set { _DescA = value; }
    }
    private int _ValueA;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"ValueA", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ValueA
    {
      get { return _ValueA; }
      set { _ValueA = value; }
    }
    private string _DescB;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"DescB", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string DescB
    {
      get { return _DescB; }
      set { _DescB = value; }
    }
    private int _ValueB;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"ValueB", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ValueB
    {
      get { return _ValueB; }
      set { _ValueB = value; }
    }
    private string _DescC;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"DescC", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string DescC
    {
      get { return _DescC; }
      set { _DescC = value; }
    }
    private int _ValueC;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"ValueC", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ValueC
    {
      get { return _ValueC; }
      set { _ValueC = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}