//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RandPropTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RandPropTable")]
  public partial class RandPropTable : global::ProtoBuf.IExtensible
  {
    public RandPropTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private ProtoTable.RandPropTable.eRandType _RandType;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"RandType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ProtoTable.RandPropTable.eRandType RandType
    {
      get { return _RandType; }
      set { _RandType = value; }
    }
    private int _Weight;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"Weight", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Weight
    {
      get { return _Weight; }
      set { _Weight = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"eRandType")]
    public enum eRandType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"STR", Value=1)]
      STR = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STA", Value=2)]
      STA = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INT", Value=3)]
      INT = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SPR", Value=4)]
      SPR = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HPMAX", Value=5)]
      HPMAX = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MPMAX", Value=6)]
      MPMAX = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HPREC", Value=7)]
      HPREC = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MPREC", Value=8)]
      MPREC = 8,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HIT", Value=9)]
      HIT = 9,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DEX", Value=10)]
      DEX = 10,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PHYCRT", Value=11)]
      PHYCRT = 11,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MGCCRT", Value=12)]
      MGCCRT = 12,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ATKSPD", Value=13)]
      ATKSPD = 13,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RDYSPD", Value=14)]
      RDYSPD = 14,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MOVSPD", Value=15)]
      MOVSPD = 15,
            
      [global::ProtoBuf.ProtoEnum(Name=@"JUMP", Value=16)]
      JUMP = 16,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HITREC", Value=17)]
      HITREC = 17
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}