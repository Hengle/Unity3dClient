//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: FightPackageTable.proto
namespace ProtoTable
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FightPackageTable")]
  public partial class FightPackageTable : global::ProtoBuf.IExtensible
  {
    public FightPackageTable() {}
    
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
    private int _Power;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"Power", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Power
    {
      get { return _Power; }
      set { _Power = value; }
    }
    private int _Intellect;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"Intellect", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Intellect
    {
      get { return _Intellect; }
      set { _Intellect = value; }
    }
    private int _Streangth;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"Streangth", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Streangth
    {
      get { return _Streangth; }
      set { _Streangth = value; }
    }
    private int _Spirit;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"Spirit", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Spirit
    {
      get { return _Spirit; }
      set { _Spirit = value; }
    }
    private int _HP;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"HP", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int HP
    {
      get { return _HP; }
      set { _HP = value; }
    }
    private int _MP;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"MP", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MP
    {
      get { return _MP; }
      set { _MP = value; }
    }
    private int _HPRecover;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"HPRecover", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int HPRecover
    {
      get { return _HPRecover; }
      set { _HPRecover = value; }
    }
    private int _MPRecover;
    [global::ProtoBuf.ProtoMember(10, IsRequired = true, Name=@"MPRecover", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MPRecover
    {
      get { return _MPRecover; }
      set { _MPRecover = value; }
    }
    private int _PhysicAttack;
    [global::ProtoBuf.ProtoMember(11, IsRequired = true, Name=@"PhysicAttack", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int PhysicAttack
    {
      get { return _PhysicAttack; }
      set { _PhysicAttack = value; }
    }
    private int _MagicAttack;
    [global::ProtoBuf.ProtoMember(12, IsRequired = true, Name=@"MagicAttack", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MagicAttack
    {
      get { return _MagicAttack; }
      set { _MagicAttack = value; }
    }
    private int _PhysicDefence;
    [global::ProtoBuf.ProtoMember(13, IsRequired = true, Name=@"PhysicDefence", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int PhysicDefence
    {
      get { return _PhysicDefence; }
      set { _PhysicDefence = value; }
    }
    private int _MagicDefence;
    [global::ProtoBuf.ProtoMember(14, IsRequired = true, Name=@"MagicDefence", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MagicDefence
    {
      get { return _MagicDefence; }
      set { _MagicDefence = value; }
    }
    private int _AttackSpeed;
    [global::ProtoBuf.ProtoMember(15, IsRequired = true, Name=@"AttackSpeed", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int AttackSpeed
    {
      get { return _AttackSpeed; }
      set { _AttackSpeed = value; }
    }
    private int _SpellSpeed;
    [global::ProtoBuf.ProtoMember(16, IsRequired = true, Name=@"SpellSpeed", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int SpellSpeed
    {
      get { return _SpellSpeed; }
      set { _SpellSpeed = value; }
    }
    private int _MoveSpeed;
    [global::ProtoBuf.ProtoMember(17, IsRequired = true, Name=@"MoveSpeed", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MoveSpeed
    {
      get { return _MoveSpeed; }
      set { _MoveSpeed = value; }
    }
    private int _PhysicalCritical;
    [global::ProtoBuf.ProtoMember(18, IsRequired = true, Name=@"PhysicalCritical", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int PhysicalCritical
    {
      get { return _PhysicalCritical; }
      set { _PhysicalCritical = value; }
    }
    private int _MagicCritical;
    [global::ProtoBuf.ProtoMember(19, IsRequired = true, Name=@"MagicCritical", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MagicCritical
    {
      get { return _MagicCritical; }
      set { _MagicCritical = value; }
    }
    private int _HitRate;
    [global::ProtoBuf.ProtoMember(20, IsRequired = true, Name=@"HitRate", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int HitRate
    {
      get { return _HitRate; }
      set { _HitRate = value; }
    }
    private int _MissRate;
    [global::ProtoBuf.ProtoMember(21, IsRequired = true, Name=@"MissRate", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MissRate
    {
      get { return _MissRate; }
      set { _MissRate = value; }
    }
    private int _StarkValue;
    [global::ProtoBuf.ProtoMember(22, IsRequired = true, Name=@"StarkValue", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int StarkValue
    {
      get { return _StarkValue; }
      set { _StarkValue = value; }
    }
    private int _HardValue;
    [global::ProtoBuf.ProtoMember(23, IsRequired = true, Name=@"HardValue", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int HardValue
    {
      get { return _HardValue; }
      set { _HardValue = value; }
    }
    private int _Cold;
    [global::ProtoBuf.ProtoMember(24, IsRequired = true, Name=@"Cold", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int Cold
    {
      get { return _Cold; }
      set { _Cold = value; }
    }
    private int _HPLevel;
    [global::ProtoBuf.ProtoMember(25, IsRequired = true, Name=@"HPLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int HPLevel
    {
      get { return _HPLevel; }
      set { _HPLevel = value; }
    }
    private int _MPLevel;
    [global::ProtoBuf.ProtoMember(26, IsRequired = true, Name=@"MPLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MPLevel
    {
      get { return _MPLevel; }
      set { _MPLevel = value; }
    }
    private int _PowerLevel;
    [global::ProtoBuf.ProtoMember(27, IsRequired = true, Name=@"PowerLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int PowerLevel
    {
      get { return _PowerLevel; }
      set { _PowerLevel = value; }
    }
    private int _IntellectLevel;
    [global::ProtoBuf.ProtoMember(28, IsRequired = true, Name=@"IntellectLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int IntellectLevel
    {
      get { return _IntellectLevel; }
      set { _IntellectLevel = value; }
    }
    private int _StrengthLevel;
    [global::ProtoBuf.ProtoMember(29, IsRequired = true, Name=@"StrengthLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int StrengthLevel
    {
      get { return _StrengthLevel; }
      set { _StrengthLevel = value; }
    }
    private int _SpiritLevel;
    [global::ProtoBuf.ProtoMember(30, IsRequired = true, Name=@"SpiritLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int SpiritLevel
    {
      get { return _SpiritLevel; }
      set { _SpiritLevel = value; }
    }
    private int _MPRecoverLevel;
    [global::ProtoBuf.ProtoMember(31, IsRequired = true, Name=@"MPRecoverLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int MPRecoverLevel
    {
      get { return _MPRecoverLevel; }
      set { _MPRecoverLevel = value; }
    }
    private int _HardValueLevel;
    [global::ProtoBuf.ProtoMember(32, IsRequired = true, Name=@"HardValueLevel", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int HardValueLevel
    {
      get { return _HardValueLevel; }
      set { _HardValueLevel = value; }
    }
    private int _TransformAttirbuleAdd;
    [global::ProtoBuf.ProtoMember(33, IsRequired = true, Name=@"TransformAttirbuleAdd", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int TransformAttirbuleAdd
    {
      get { return _TransformAttirbuleAdd; }
      set { _TransformAttirbuleAdd = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}