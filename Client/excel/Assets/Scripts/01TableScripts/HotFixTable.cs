//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: HotFixTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"HotFixTable")]
  public partial class HotFixTable : global::ProtoBuf.IExtensible,global::ProtoBuf.IParseable
  {
    public HotFixTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private string _Descrip;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"Descrip", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Descrip
    {
      get { return _Descrip; }
      set { _Descrip = value; }
    }
    private string _ResourceName;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"ResourceName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ResourceName
    {
      get { return _ResourceName; }
      set { _ResourceName = value; }
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
                    
            case 2:   //Descrip LABEL_REQUIRED TYPE_STRING  TwosComplement
                    Descrip = source.ReadString();
                    break;
                    
            case 3:   //ResourceName LABEL_REQUIRED TYPE_STRING  TwosComplement
                    ResourceName = source.ReadString();
                    break;
                    
            }
        }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}