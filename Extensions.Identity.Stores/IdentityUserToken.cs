using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Extensions.Identity.Stores.XCode
{
    /// <summary>IdentityUserToken(用户的身份验证令牌)</summary>
    [Serializable]
    [DataObject]
    [Description("IdentityUserToken(用户的身份验证令牌)")]
    [BindIndex("IX_IdentityUserToken_UserId", false, "UserId")]
    [BindIndex("IX_IdentityUserToken_LoginProvider", false, "LoginProvider")]
    [BindIndex("IX_IdentityUserToken_UserId_LoginProvider", false, "UserId,LoginProvider")]
    [BindIndex("IX_IdentityUserToken_UserId_LoginProvider_Name", false, "UserId,LoginProvider,Name")]
    [BindTable("IdentityUserToken", Description = "IdentityUserToken(用户的身份验证令牌)", ConnName = "Users", DbType = DatabaseType.None)]
    public partial class IdentityUserToken<TEntity> : IIdentityUserToken
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

        private String _LoginProvider;
        /// <summary>登录提供者</summary>
        [DisplayName("登录提供者")]
        [Description("登录提供者")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn("LoginProvider", "登录提供者", "")]
        public String LoginProvider { get { return _LoginProvider; } set { if (OnPropertyChanging(__.LoginProvider, value)) { _LoginProvider = value; OnPropertyChanged(__.LoginProvider); } } }

        private String _Name;
        /// <summary>token名</summary>
        [DisplayName("token名")]
        [Description("token名")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn("Name", "token名", "", Master = true)]
        public String Name { get { return _Name; } set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } } }

        private String _Value;
        /// <summary>token</summary>
        [DisplayName("token")]
        [Description("token")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Value", "token", "")]
        public String Value { get { return _Value; } set { if (OnPropertyChanging(__.Value, value)) { _Value = value; OnPropertyChanged(__.Value); } } }
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
                    case __.Name : return _Name;
                    case __.Value : return _Value;
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
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Value : _Value = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityUserToken字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>用户编号</summary>
            public static readonly Field UserId = FindByName(__.UserId);

            /// <summary>登录提供者</summary>
            public static readonly Field LoginProvider = FindByName(__.LoginProvider);

            /// <summary>token名</summary>
            public static readonly Field Name = FindByName(__.Name);

            /// <summary>token</summary>
            public static readonly Field Value = FindByName(__.Value);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得IdentityUserToken字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>用户编号</summary>
            public const String UserId = "UserId";

            /// <summary>登录提供者</summary>
            public const String LoginProvider = "LoginProvider";

            /// <summary>token名</summary>
            public const String Name = "Name";

            /// <summary>token</summary>
            public const String Value = "Value";
        }
        #endregion
    }

    /// <summary>IdentityUserToken(用户的身份验证令牌)接口</summary>
    public partial interface IIdentityUserToken
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>用户编号</summary>
        Int32 UserId { get; set; }

        /// <summary>登录提供者</summary>
        String LoginProvider { get; set; }

        /// <summary>token名</summary>
        String Name { get; set; }

        /// <summary>token</summary>
        String Value { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}