using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Extensions.Identity.Stores.XCode
{
    /// <summary>IdentityRoleClaim(角色声明集合)</summary>
    [Serializable]
    [DataObject]
    [Description("IdentityRoleClaim(角色声明集合)")]
    [BindIndex("IX_IdentityRoleClaim_RoleId", false, "RoleId")]
    [BindTable("IdentityRoleClaim", Description = "IdentityRoleClaim(角色声明集合)", ConnName = "Users", DbType = DatabaseType.None)]
    public partial class IdentityRoleClaim<TEntity> : IIdentityRoleClaim
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "编号", "")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private Int32 _RoleId;
        /// <summary>角色编号</summary>
        [DisplayName("角色编号")]
        [Description("角色编号")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("RoleId", "角色编号", "")]
        public Int32 RoleId { get { return _RoleId; } set { if (OnPropertyChanging(__.RoleId, value)) { _RoleId = value; OnPropertyChanged(__.RoleId); } } }

        private String _ClaimType;
        /// <summary>声明类型</summary>
        [DisplayName("声明类型")]
        [Description("声明类型")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("ClaimType", "声明类型", "")]
        public String ClaimType { get { return _ClaimType; } set { if (OnPropertyChanging(__.ClaimType, value)) { _ClaimType = value; OnPropertyChanged(__.ClaimType); } } }

        private String _ClaimValue;
        /// <summary>声明值</summary>
        [DisplayName("声明值")]
        [Description("声明值")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("ClaimValue", "声明值", "")]
        public String ClaimValue { get { return _ClaimValue; } set { if (OnPropertyChanging(__.ClaimValue, value)) { _ClaimValue = value; OnPropertyChanged(__.ClaimValue); } } }
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
                    case __.RoleId : return _RoleId;
                    case __.ClaimType : return _ClaimType;
                    case __.ClaimValue : return _ClaimValue;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = value.ToInt(); break;
                    case __.RoleId : _RoleId = value.ToInt(); break;
                    case __.ClaimType : _ClaimType = Convert.ToString(value); break;
                    case __.ClaimValue : _ClaimValue = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityRoleClaim字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>角色编号</summary>
            public static readonly Field RoleId = FindByName(__.RoleId);

            /// <summary>声明类型</summary>
            public static readonly Field ClaimType = FindByName(__.ClaimType);

            /// <summary>声明值</summary>
            public static readonly Field ClaimValue = FindByName(__.ClaimValue);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得IdentityRoleClaim字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>角色编号</summary>
            public const String RoleId = "RoleId";

            /// <summary>声明类型</summary>
            public const String ClaimType = "ClaimType";

            /// <summary>声明值</summary>
            public const String ClaimValue = "ClaimValue";
        }
        #endregion
    }

    /// <summary>IdentityRoleClaim(角色声明集合)接口</summary>
    public partial interface IIdentityRoleClaim
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>角色编号</summary>
        Int32 RoleId { get; set; }

        /// <summary>声明类型</summary>
        String ClaimType { get; set; }

        /// <summary>声明值</summary>
        String ClaimValue { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}