//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: TalkTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TalkTable")]
  public partial class TalkTable : global::ProtoBuf.IExtensible
  {
    public TalkTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private string _ObjectName;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"ObjectName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ObjectName
    {
      get { return _ObjectName; }
      set { _ObjectName = value; }
    }
    private int _NpcID;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"NpcID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int NpcID
    {
      get { return _NpcID; }
      set { _NpcID = value; }
    }
    private string _TalkText;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"TalkText", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string TalkText
    {
      get { return _TalkText; }
      set { _TalkText = value; }
    }
    private int _NextID;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"NextID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int NextID
    {
      get { return _NextID; }
      set { _NextID = value; }
    }
    private int _MissionID;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"MissionID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MissionID
    {
      get { return _MissionID; }
      set { _MissionID = value; }
    }
    private int _TakeFinish;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"TakeFinish", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int TakeFinish
    {
      get { return _TakeFinish; }
      set { _TakeFinish = value; }
    }
    private string _FrameClassName;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"FrameClassName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string FrameClassName
    {
      get { return _FrameClassName; }
      set { _FrameClassName = value; }
    }
    private string _AttachClassName;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"AttachClassName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string AttachClassName
    {
      get { return _AttachClassName; }
      set { _AttachClassName = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}