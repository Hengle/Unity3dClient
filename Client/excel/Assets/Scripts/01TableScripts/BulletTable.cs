//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: BulletTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BulletTable")]
  public partial class BulletTable : global::ProtoBuf.IExtensible,global::ProtoBuf.IParseable
  {
    public BulletTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private string _Prefab;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"Prefab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Prefab
    {
      get { return _Prefab; }
      set { _Prefab = value; }
    }
    private int _Speed;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"Speed", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Speed
    {
      get { return _Speed; }
      set { _Speed = value; }
    }
    public void Parse(ProtoBuf.ProtoReader source){
        int fieldNumber = 0;
        while ((fieldNumber = source.ReadFieldHeader()) > 0)
        {
            switch (fieldNumber)
            {
                default:
                    source.SkipField();
                    break;
            
    
            case 1:   //ID LABEL_REQUIRED TYPE_SINT32  ZigZag
                    source.Hint(ProtoBuf.WireType.SignedVariant); 
                    ID = source.ReadInt32();
                    break;
                    
            case 2:   //Prefab LABEL_REQUIRED TYPE_STRING  TwosComplement
                    Prefab = source.ReadString();
                    break;
                    
            case 3:   //Speed LABEL_REQUIRED TYPE_SINT32  ZigZag
                    source.Hint(ProtoBuf.WireType.SignedVariant); 
                    Speed = source.ReadInt32();
                    break;
                    
            }
        }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}