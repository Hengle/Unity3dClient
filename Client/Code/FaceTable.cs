//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: FaceTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FaceTable")]
  public partial class FaceTable : global::ProtoBuf.IExtensible
  {
    public FaceTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private ProtoTable.FaceTable.eGroup _Group;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"Group", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ProtoTable.FaceTable.eGroup Group
    {
      get { return _Group; }
      set { _Group = value; }
    }
    private string _Path;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"Path", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Path
    {
      get { return _Path; }
      set { _Path = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"eGroup")]
    public enum eGroup
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"Team", Value=0)]
      Team = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"Normal", Value=1)]
      Normal = 1
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}