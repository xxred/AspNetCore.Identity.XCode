using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Extensions.Identity.Stores.XCode
{
    /// <summary>IdentityUserLogin(用户的登录及其关联的提供程序)</summary>
    [Serializable]
    [DataObject]
    [Description("IdentityUserLogin(用户的登录及其关联的提供程序)")]
    [BindIndex("IX_IdentityUserLogin_UserId", false, "UserId")]
    [BindIndex("IX_IdentityUserRole_LoginProvider_ProviderKey", false, "LoginProvider,ProviderKey")]
    [BindTable("IdentityUserLogin", Description = "IdentityUserLogin(用户的登录及其关联的提供程序)", ConnName = "Users", DbType = DatabaseType.None)]
    public partial class IdentityUserLogin<TEntity> : IIdentityUserLogin
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
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UserId", "用户编号", "")]
        public Int32 UserId { get { return _UserId; } set { if (OnPropertyChanging(__.UserId, value)) { _UserId = value; OnPropertyChanged(__.UserId); } } }

        private String _LoginProvider;
        /// <summary>登录提供者</summary>
        [DisplayName("登录提供者")]
        [Description("登录提供者")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn("LoginProvider", "登录提供者", "")]
        public String LoginProvider { get { return _LoginProvider; } set { if (OnPropertyChanging(__.LoginProvider, value)) { _LoginProvider = value; OnPropertyChanged(__.LoginProvider); } } }

        private String _ProviderKey;
        /// <summary>提供者标识符(此次登录提供程序唯一标识符)</summary>
        [DisplayName("提供者标识符")]
        [Description("提供者标识符(此次登录提供程序唯一标识符)")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn("ProviderKey", "提供者标识符(此次登录提供程序唯一标识符)", "")]
        public String ProviderKey { get { return _ProviderKey; } set { if (OnPropertyChanging(__.ProviderKey, value)) { _ProviderKey = value; OnPropertyChanged(__.ProviderKey); } } }

        private String _ProviderDisplayName;
        /// <summary>提供者名称(登录提供程序友好名称)</summary>
        [DisplayName("提供者名称")]
        [Description("提供者名称(登录提供程序友好名称)")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ProviderDisplayName", "提供者名称(登录提供程序友好名称)", "")]
        public String ProviderDisplayName { get { return _ProviderDisplayName; } set { if (OnPropertyChanging(__.ProviderDisplayName, value)) { _ProviderDisplayName = value; OnPropertyChanged(__.ProviderDisplayName); } } }
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
                    case __.LoginProvider : return _LoginProvider;
                    case __.ProviderKey : return _ProviderKey;
                    case __.ProviderDisplayName : return _ProviderDisplayName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = value.ToInt(); break;
                    case __.UserId : _UserId = value.ToInt(); break;
                    case __.LoginProvider : _LoginProvider = Convert.ToString(value); break;
                    case __.ProviderKey : _ProviderKey = Convert.ToString(value); break;
                    case __.ProviderDisplayName : _ProviderDisplayName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityUserLogin字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>用户编号</summary>
            public static readonly Field UserId = FindByName(__.UserId);

            /// <summary>登录提供者</summary>
            public static readonly Field LoginProvider = FindByName(__.LoginProvider);

            /// <summary>提供者标识符(此次登录提供程序唯一标识符)</summary>
            public static readonly Field ProviderKey = FindByName(__.ProviderKey);

            /// <summary>提供者名称(登录提供程序友好名称)</summary>
            public static readonly Field ProviderDisplayName = FindByName(__.ProviderDisplayName);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得IdentityUserLogin字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>用户编号</summary>
            public const String UserId = "UserId";

            /// <summary>登录提供者</summary>
            public const String LoginProvider = "LoginProvider";

            /// <summary>提供者标识符(此次登录提供程序唯一标识符)</summary>
            public const String ProviderKey = "ProviderKey";

            /// <summary>提供者名称(登录提供程序友好名称)</summary>
            public const String ProviderDisplayName = "ProviderDisplayName";
        }
        #endregion
    }

    /// <summary>IdentityUserLogin(用户的登录及其关联的提供程序)接口</summary>
    public partial interface IIdentityUserLogin
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>用户编号</summary>
        Int32 UserId { get; set; }

        /// <summary>登录提供者</summary>
        String LoginProvider { get; set; }

        /// <summary>提供者标识符(此次登录提供程序唯一标识符)</summary>
        String ProviderKey { get; set; }

        /// <summary>提供者名称(登录提供程序友好名称)</summary>
        String ProviderDisplayName { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}