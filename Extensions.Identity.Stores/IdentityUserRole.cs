using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Extensions.Identity.Stores.XCode
{
    /// <summary>IdentityUserRole(用户角色关联)</summary>
    [Serializable]
    [DataObject]
    [Description("IdentityUserRole(用户角色关联)")]
    [BindIndex("IX_IdentityUserRole_UserId", false, "UserId")]
    [BindIndex("IX_IdentityUserRole_RoleId", false, "RoleId")]
    [BindTable("IdentityUserRole", Description = "IdentityUserRole(用户角色关联)", ConnName = "Users", DbType = DatabaseType.None)]
    public partial class IdentityUserRole<TEntity> : IIdentityUserRole
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(false, true, false, 0)]
        [BindColumn("Id", "编号", "")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private Int32 _UserId;
        /// <summary>用户编号</summary>
        [DisplayName("用户编号")]
        [Description("用户编号")]
        [DataObjectField(true, false, false, 0)]
        [BindColumn("UserId", "用户编号", "")]
        public Int32 UserId { get { return _UserId; } set { if (OnPropertyChanging(__.UserId, value)) { _UserId = value; OnPropertyChanged(__.UserId); } } }

        private Int32 _RoleId;
        /// <summary>角色编号</summary>
        [DisplayName("角色编号")]
        [Description("角色编号")]
        [DataObjectField(true, false, false, 0)]
        [BindColumn("RoleId", "角色编号", "")]
        public Int32 RoleId { get { return _RoleId; } set { if (OnPropertyChanging(__.RoleId, value)) { _RoleId = value; OnPropertyChanged(__.RoleId); } } }
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
                    case __.UserId : return _UserId;
                    case __.RoleId : return _RoleId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = value.ToInt(); break;
                    case __.UserId : _UserId = value.ToInt(); break;
                    case __.RoleId : _RoleId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityUserRole字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>用户编号</summary>
            public static readonly Field UserId = FindByName(__.UserId);

            /// <summary>角色编号</summary>
            public static readonly Field RoleId = FindByName(__.RoleId);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得IdentityUserRole字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>用户编号</summary>
            public const String UserId = "UserId";

            /// <summary>角色编号</summary>
            public const String RoleId = "RoleId";
        }
        #endregion
    }

    /// <summary>IdentityUserRole(用户角色关联)接口</summary>
    public partial interface IIdentityUserRole
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>用户编号</summary>
        Int32 UserId { get; set; }

        /// <summary>角色编号</summary>
        Int32 RoleId { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}