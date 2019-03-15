using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Extensions.Identity.Stores.XCode
{
    /// <summary>IdentityRole(角色)</summary>
    [Serializable]
    [DataObject]
    [Description("IdentityRole(角色)")]
    [BindIndex("IU_IdentityRole_Name", true, "Name")]
    [BindTable("IdentityRole", Description = "IdentityRole(角色)", ConnName = "Users", DbType = DatabaseType.None)]
    public partial class IdentityRole<TEntity> : IIdentityRole
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "编号", "")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get { return _Name; } set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } } }

        private String _NormalizedName;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("NormalizedName", "名称", "", Master = true)]
        public String NormalizedName { get { return _NormalizedName; } set { if (OnPropertyChanging(__.NormalizedName, value)) { _NormalizedName = value; OnPropertyChanged(__.NormalizedName); } } }

        private String _ConcurrencyStamp;
        /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
        [DisplayName("存储随机值")]
        [Description("存储随机值(当用户被持久化到存储时必须更改的随机值)")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ConcurrencyStamp", "存储随机值(当用户被持久化到存储时必须更改的随机值)", "")]
        public String ConcurrencyStamp { get { return _ConcurrencyStamp; } set { if (OnPropertyChanging(__.ConcurrencyStamp, value)) { _ConcurrencyStamp = value; OnPropertyChanged(__.ConcurrencyStamp); } } }

        private Boolean _IsSystem;
        /// <summary>系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除</summary>
        [DisplayName("系统")]
        [Description("系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsSystem", "系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除", "")]
        public Boolean IsSystem { get { return _IsSystem; } set { if (OnPropertyChanging(__.IsSystem, value)) { _IsSystem = value; OnPropertyChanged(__.IsSystem); } } }

        private String _Remark;
        /// <summary>说明</summary>
        [DisplayName("说明")]
        [Description("说明")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Remark", "说明", "")]
        public String Remark { get { return _Remark; } set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } } }

        private Int32 _CreateUserID;
        /// <summary>创建用户</summary>
        [DisplayName("创建用户")]
        [Description("创建用户")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CreateUserID", "创建用户", "")]
        public Int32 CreateUserID { get { return _CreateUserID; } set { if (OnPropertyChanging(__.CreateUserID, value)) { _CreateUserID = value; OnPropertyChanged(__.CreateUserID); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "")]
        public String CreateIP { get { return _CreateIP; } set { if (OnPropertyChanging(__.CreateIP, value)) { _CreateIP = value; OnPropertyChanged(__.CreateIP); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "")]
        public DateTime CreateTime { get { return _CreateTime; } set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新用户</summary>
        [DisplayName("更新用户")]
        [Description("更新用户")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UpdateUserID", "更新用户", "")]
        public Int32 UpdateUserID { get { return _UpdateUserID; } set { if (OnPropertyChanging(__.UpdateUserID, value)) { _UpdateUserID = value; OnPropertyChanged(__.UpdateUserID); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "")]
        public String UpdateIP { get { return _UpdateIP; } set { if (OnPropertyChanging(__.UpdateIP, value)) { _UpdateIP = value; OnPropertyChanged(__.UpdateIP); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "")]
        public DateTime UpdateTime { get { return _UpdateTime; } set { if (OnPropertyChanging(__.UpdateTime, value)) { _UpdateTime = value; OnPropertyChanged(__.UpdateTime); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.Id : return _Id;
                    case __.Name : return _Name;
                    case __.NormalizedName : return _NormalizedName;
                    case __.ConcurrencyStamp : return _ConcurrencyStamp;
                    case __.IsSystem : return _IsSystem;
                    case __.Remark : return _Remark;
                    case __.CreateUserID : return _CreateUserID;
                    case __.CreateIP : return _CreateIP;
                    case __.CreateTime : return _CreateTime;
                    case __.UpdateUserID : return _UpdateUserID;
                    case __.UpdateIP : return _UpdateIP;
                    case __.UpdateTime : return _UpdateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = value.ToInt(); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.NormalizedName : _NormalizedName = Convert.ToString(value); break;
                    case __.ConcurrencyStamp : _ConcurrencyStamp = Convert.ToString(value); break;
                    case __.IsSystem : _IsSystem = value.ToBoolean(); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    case __.CreateUserID : _CreateUserID = value.ToInt(); break;
                    case __.CreateIP : _CreateIP = Convert.ToString(value); break;
                    case __.CreateTime : _CreateTime = value.ToDateTime(); break;
                    case __.UpdateUserID : _UpdateUserID = value.ToInt(); break;
                    case __.UpdateIP : _UpdateIP = Convert.ToString(value); break;
                    case __.UpdateTime : _UpdateTime = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityRole字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            /// <summary>名称</summary>
            public static readonly Field NormalizedName = FindByName(__.NormalizedName);

            /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
            public static readonly Field ConcurrencyStamp = FindByName(__.ConcurrencyStamp);

            /// <summary>系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除</summary>
            public static readonly Field IsSystem = FindByName(__.IsSystem);

            /// <summary>说明</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            /// <summary>创建用户</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            /// <summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName(__.CreateIP);

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            /// <summary>更新用户</summary>
            public static readonly Field UpdateUserID = FindByName(__.UpdateUserID);

            /// <summary>更新地址</summary>
            public static readonly Field UpdateIP = FindByName(__.UpdateIP);

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得IdentityRole字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>名称</summary>
            public const String NormalizedName = "NormalizedName";

            /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
            public const String ConcurrencyStamp = "ConcurrencyStamp";

            /// <summary>系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除</summary>
            public const String IsSystem = "IsSystem";

            /// <summary>说明</summary>
            public const String Remark = "Remark";

            /// <summary>创建用户</summary>
            public const String CreateUserID = "CreateUserID";

            /// <summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>更新用户</summary>
            public const String UpdateUserID = "UpdateUserID";

            /// <summary>更新地址</summary>
            public const String UpdateIP = "UpdateIP";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";
        }
        #endregion
    }

    /// <summary>IdentityRole(角色)接口</summary>
    public partial interface IIdentityRole
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>名称</summary>
        String NormalizedName { get; set; }

        /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
        String ConcurrencyStamp { get; set; }

        /// <summary>系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除</summary>
        Boolean IsSystem { get; set; }

        /// <summary>说明</summary>
        String Remark { get; set; }

        /// <summary>创建用户</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>创建地址</summary>
        String CreateIP { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>更新用户</summary>
        Int32 UpdateUserID { get; set; }

        /// <summary>更新地址</summary>
        String UpdateIP { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}