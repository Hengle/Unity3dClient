//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RetinueLuckTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RetinueLuckTable")]
  public partial class RetinueLuckTable : global::ProtoBuf.IExtensible
  {
    public RetinueLuckTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private int _IncExp;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"IncExp", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int IncExp
    {
      get { return _IncExp; }
      set { _IncExp = value; }
    }
    private int _Exp;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"Exp", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Exp
    {
      get { return _Exp; }
      set { _Exp = value; }
    }
    private int _UpPreLvNeedExp;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"UpPreLvNeedExp", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int UpPreLvNeedExp
    {
      get { return _UpPreLvNeedExp; }
      set { _UpPreLvNeedExp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}