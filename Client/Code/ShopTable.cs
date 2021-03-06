//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ShopTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ShopTable")]
  public partial class ShopTable : global::ProtoBuf.IExtensible
  {
    public ShopTable() {}
    
    private int _ID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    private string _ShopName;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"ShopName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ShopName
    {
      get { return _ShopName; }
      set { _ShopName = value; }
    }
    private string _ShopNamePath;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"ShopNamePath", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ShopNamePath
    {
      get { return _ShopNamePath; }
      set { _ShopNamePath = value; }
    }
    private string _ShopMallIcon;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"ShopMallIcon", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ShopMallIcon
    {
      get { return _ShopMallIcon; }
      set { _ShopMallIcon = value; }
    }
    private string _Link;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"Link", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Link
    {
      get { return _Link; }
      set { _Link = value; }
    }
    private ProtoTable.ShopTable.eShopKind _ShopKind;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"ShopKind", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ProtoTable.ShopTable.eShopKind ShopKind
    {
      get { return _ShopKind; }
      set { _ShopKind = value; }
    }
    private int _HelpID;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"HelpID", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int HelpID
    {
      get { return _HelpID; }
      set { _HelpID = value; }
    }
    private int _IsGuildShop;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"IsGuildShop", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int IsGuildShop
    {
      get { return _IsGuildShop; }
      set { _IsGuildShop = value; }
    }
    private int _OccuFilter;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"OccuFilter", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int OccuFilter
    {
      get { return _OccuFilter; }
      set { _OccuFilter = value; }
    }
    private readonly global::System.Collections.Generic.List<ProtoTable.ShopTable.eSubType> _SubType = new global::System.Collections.Generic.List<ProtoTable.ShopTable.eSubType>();
    [global::ProtoBuf.ProtoMember(10, Name=@"SubType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<ProtoTable.ShopTable.eSubType> SubType
    {
      get { return _SubType; }
    }
  
    private string _ExtraShowMoneys;
    [global::ProtoBuf.ProtoMember(11, IsRequired = true, Name=@"ExtraShowMoneys", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ExtraShowMoneys
    {
      get { return _ExtraShowMoneys; }
      set { _ExtraShowMoneys = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _NeedRefreshTabs = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(12, Name=@"NeedRefreshTabs", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public global::System.Collections.Generic.List<int> NeedRefreshTabs
    {
      get { return _NeedRefreshTabs; }
    }
  
    private int _Refresh;
    [global::ProtoBuf.ProtoMember(13, IsRequired = true, Name=@"Refresh", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Refresh
    {
      get { return _Refresh; }
      set { _Refresh = value; }
    }
    private int _OpenLevel;
    [global::ProtoBuf.ProtoMember(14, IsRequired = true, Name=@"OpenLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int OpenLevel
    {
      get { return _OpenLevel; }
      set { _OpenLevel = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _RefreshCost = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(15, Name=@"RefreshCost", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public global::System.Collections.Generic.List<int> RefreshCost
    {
      get { return _RefreshCost; }
    }
  
    private readonly global::System.Collections.Generic.List<int> _RefreshTime = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(16, Name=@"RefreshTime", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public global::System.Collections.Generic.List<int> RefreshTime
    {
      get { return _RefreshTime; }
    }
  
    private int _OnSaleNum;
    [global::ProtoBuf.ProtoMember(17, IsRequired = true, Name=@"OnSaleNum", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int OnSaleNum
    {
      get { return _OnSaleNum; }
      set { _OnSaleNum = value; }
    }
    private readonly global::System.Collections.Generic.List<ProtoTable.ShopTable.eSubTypeOrder> _SubTypeOrder = new global::System.Collections.Generic.List<ProtoTable.ShopTable.eSubTypeOrder>();
    [global::ProtoBuf.ProtoMember(18, Name=@"SubTypeOrder", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<ProtoTable.ShopTable.eSubTypeOrder> SubTypeOrder
    {
      get { return _SubTypeOrder; }
    }
  
    private int _LimitGood1;
    [global::ProtoBuf.ProtoMember(19, IsRequired = true, Name=@"LimitGood1", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int LimitGood1
    {
      get { return _LimitGood1; }
      set { _LimitGood1 = value; }
    }
    private int _LimitGood2;
    [global::ProtoBuf.ProtoMember(20, IsRequired = true, Name=@"LimitGood2", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int LimitGood2
    {
      get { return _LimitGood2; }
      set { _LimitGood2 = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _VIPLv = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(21, Name=@"VIPLv", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public global::System.Collections.Generic.List<int> VIPLv
    {
      get { return _VIPLv; }
    }
  
    private readonly global::System.Collections.Generic.List<int> _VIPDiscount = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(22, Name=@"VIPDiscount", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public global::System.Collections.Generic.List<int> VIPDiscount
    {
      get { return _VIPDiscount; }
    }
  
    private int _Version;
    [global::ProtoBuf.ProtoMember(23, IsRequired = true, Name=@"Version", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Version
    {
      get { return _Version; }
      set { _Version = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"eShopKind")]
    public enum eShopKind
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Ancient", Value=0)]
      SK_Ancient = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Mystery", Value=1)]
      SK_Mystery = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Forge", Value=2)]
      SK_Forge = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Brave", Value=3)]
      SK_Brave = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Fight", Value=4)]
      SK_Fight = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Guild", Value=5)]
      SK_Guild = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Magic", Value=6)]
      SK_Magic = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Gold", Value=7)]
      SK_Gold = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SK_Abyss", Value=8)]
      SK_Abyss = 8
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"eSubType")]
    public enum eSubType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_NONE", Value=0)]
      ST_NONE = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_MATERIAL", Value=1)]
      ST_MATERIAL = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_WEAPON", Value=2)]
      ST_WEAPON = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_ARMOR", Value=3)]
      ST_ARMOR = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_JEWELRY", Value=4)]
      ST_JEWELRY = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_COST", Value=5)]
      ST_COST = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_VALUABLE", Value=6)]
      ST_VALUABLE = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_RETINUE", Value=7)]
      ST_RETINUE = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_TITLE", Value=8)]
      ST_TITLE = 8,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_ENERGY", Value=9)]
      ST_ENERGY = 9,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_FASHION", Value=10)]
      ST_FASHION = 10,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_ORDINARY", Value=11)]
      ST_ORDINARY = 11,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_DAILY", Value=12)]
      ST_DAILY = 12,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_GOODS", Value=13)]
      ST_GOODS = 13,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ST_EQUIP", Value=14)]
      ST_EQUIP = 14
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"eSubTypeOrder")]
    public enum eSubTypeOrder
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"STO_NONE", Value=0)]
      STO_NONE = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STO_EQUIP", Value=1)]
      STO_EQUIP = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STO_EXPENDABLE", Value=2)]
      STO_EXPENDABLE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STO_MATERIAL", Value=3)]
      STO_MATERIAL = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STO_TASK", Value=4)]
      STO_TASK = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STO_FASHION", Value=5)]
      STO_FASHION = 5
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}