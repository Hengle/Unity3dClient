//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: DefaultAdminServerTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DefaultAdminServerTable")]
  public partial class DefaultAdminServerTable : global::ProtoBuf.IExtensible
  {
    public DefaultAdminServerTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private string _ServerID;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"ServerID", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ServerID
    {
      get { return _ServerID; }
      set { _ServerID = value; }
    }
    private string _ServerIP;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"ServerIP", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ServerIP
    {
      get { return _ServerIP; }
      set { _ServerIP = value; }
    }
    private string _ServerName;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"ServerName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ServerName
    {
      get { return _ServerName; }
      set { _ServerName = value; }
    }
    private int _ServerPort;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"ServerPort", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ServerPort
    {
      get { return _ServerPort; }
      set { _ServerPort = value; }
    }
    private int _ServerStaus;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"ServerStaus", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ServerStaus
    {
      get { return _ServerStaus; }
      set { _ServerStaus = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}