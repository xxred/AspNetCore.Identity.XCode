using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Extensions.Identity.Stores.XCode
{
    /// <summary>IdentityUser(用户)</summary>
    [Serializable]
    [DataObject]
    [Description("IdentityUser(用户)")]
    [BindIndex("IU_IdentityUser_UserName", true, "UserName")]
    [BindIndex("IX_IdentityUser_Email", false, "Email")]
    [BindIndex("IX_IdentityUser_PhoneNumber", false, "PhoneNumber")]
    [BindTable("IdentityUser", Description = "IdentityUser(用户)", ConnName = "Users", DbType = DatabaseType.SqlServer)]
    public partial class IdentityUser<TEntity> : IIdentityUser
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "编号", "")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _UserName;
        /// <summary>名称。登录用户名</summary>
        [DisplayName("名称")]
        [Description("名称。登录用户名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("UserName", "名称。登录用户名", "", Master = true)]
        public String UserName { get { return _UserName; } set { if (OnPropertyChanging(__.UserName, value)) { _UserName = value; OnPropertyChanged(__.UserName); } } }

        private String _NormalizedUserName;
        /// <summary>友好显示名</summary>
        [DisplayName("友好显示名")]
        [Description("友好显示名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("NormalizedUserName", "友好显示名", "", Master = true)]
        public String NormalizedUserName { get { return _NormalizedUserName; } set { if (OnPropertyChanging(__.NormalizedUserName, value)) { _NormalizedUserName = value; OnPropertyChanged(__.NormalizedUserName); } } }

        private String _Email;
        /// <summary>邮件</summary>
        [DisplayName("邮件")]
        [Description("邮件")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Email", "邮件", "")]
        public String Email { get { return _Email; } set { if (OnPropertyChanging(__.Email, value)) { _Email = value; OnPropertyChanged(__.Email); } } }

        private String _NormalizedEmail;
        /// <summary>规范化的邮件</summary>
        [DisplayName("规范化的邮件")]
        [Description("规范化的邮件")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("NormalizedEmail", "规范化的邮件", "")]
        public String NormalizedEmail { get { return _NormalizedEmail; } set { if (OnPropertyChanging(__.NormalizedEmail, value)) { _NormalizedEmail = value; OnPropertyChanged(__.NormalizedEmail); } } }

        private Boolean _EmailConfirmed;
        /// <summary>邮箱验证(指示用户是否已验证其邮箱)</summary>
        [DisplayName("邮箱验证")]
        [Description("邮箱验证(指示用户是否已验证其邮箱)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("EmailConfirmed", "邮箱验证(指示用户是否已验证其邮箱)", "")]
        public Boolean EmailConfirmed { get { return _EmailConfirmed; } set { if (OnPropertyChanging(__.EmailConfirmed, value)) { _EmailConfirmed = value; OnPropertyChanged(__.EmailConfirmed); } } }

        private String _PasswordHash;
        /// <summary>密码哈希(获取或设置此用户密码的salt和hash表示形式)</summary>
        [DisplayName("密码哈希")]
        [Description("密码哈希(获取或设置此用户密码的salt和hash表示形式)")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PasswordHash", "密码哈希(获取或设置此用户密码的salt和hash表示形式)", "")]
        public String PasswordHash { get { return _PasswordHash; } set { if (OnPropertyChanging(__.PasswordHash, value)) { _PasswordHash = value; OnPropertyChanged(__.PasswordHash); } } }

        private String _SecurityStamp;
        /// <summary>凭据随机值(当用户凭据更改时必须更改的随机值,比如更改密码、删除登录名)</summary>
        [DisplayName("凭据随机值")]
        [Description("凭据随机值(当用户凭据更改时必须更改的随机值,比如更改密码、删除登录名)")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SecurityStamp", "凭据随机值(当用户凭据更改时必须更改的随机值,比如更改密码、删除登录名)", "")]
        public String SecurityStamp { get { return _SecurityStamp; } set { if (OnPropertyChanging(__.SecurityStamp, value)) { _SecurityStamp = value; OnPropertyChanged(__.SecurityStamp); } } }

        private String _ConcurrencyStamp;
        /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
        [DisplayName("存储随机值")]
        [Description("存储随机值(当用户被持久化到存储时必须更改的随机值)")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ConcurrencyStamp", "存储随机值(当用户被持久化到存储时必须更改的随机值)", "")]
        public String ConcurrencyStamp { get { return _ConcurrencyStamp; } set { if (OnPropertyChanging(__.ConcurrencyStamp, value)) { _ConcurrencyStamp = value; OnPropertyChanged(__.ConcurrencyStamp); } } }

        private String _PhoneNumber;
        /// <summary>手机号</summary>
        [DisplayName("手机号")]
        [Description("手机号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PhoneNumber", "手机号", "")]
        public String PhoneNumber { get { return _PhoneNumber; } set { if (OnPropertyChanging(__.PhoneNumber, value)) { _PhoneNumber = value; OnPropertyChanged(__.PhoneNumber); } } }

        private Boolean _PhoneNumberConfirmed;
        /// <summary>手机号验证(指示用户是否已验证其手机号)</summary>
        [DisplayName("手机号验证")]
        [Description("手机号验证(指示用户是否已验证其手机号)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("PhoneNumberConfirmed", "手机号验证(指示用户是否已验证其手机号)", "")]
        public Boolean PhoneNumberConfirmed { get { return _PhoneNumberConfirmed; } set { if (OnPropertyChanging(__.PhoneNumberConfirmed, value)) { _PhoneNumberConfirmed = value; OnPropertyChanged(__.PhoneNumberConfirmed); } } }

        private Boolean _TwoFactorEnabled;
        /// <summary>双重验证(指示是否为此用户启用了双重身份验证)</summary>
        [DisplayName("双重验证")]
        [Description("双重验证(指示是否为此用户启用了双重身份验证)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("TwoFactorEnabled", "双重验证(指示是否为此用户启用了双重身份验证)", "")]
        public Boolean TwoFactorEnabled { get { return _TwoFactorEnabled; } set { if (OnPropertyChanging(__.TwoFactorEnabled, value)) { _TwoFactorEnabled = value; OnPropertyChanged(__.TwoFactorEnabled); } } }

        private DateTime _LockoutEnd;
        /// <summary>最后锁定时间</summary>
        [DisplayName("最后锁定时间")]
        [Description("最后锁定时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LockoutEnd", "最后锁定时间", "")]
        public DateTime LockoutEnd { get { return _LockoutEnd; } set { if (OnPropertyChanging(__.LockoutEnd, value)) { _LockoutEnd = value; OnPropertyChanged(__.LockoutEnd); } } }

        private Boolean _LockoutEnabled;
        /// <summary>启用锁定</summary>
        [DisplayName("启用锁定")]
        [Description("启用锁定")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("LockoutEnabled", "启用锁定", "")]
        public Boolean LockoutEnabled { get { return _LockoutEnabled; } set { if (OnPropertyChanging(__.LockoutEnabled, value)) { _LockoutEnabled = value; OnPropertyChanged(__.LockoutEnabled); } } }

        private Int32 _AccessFailedCount;
        /// <summary>失败登录尝试次数</summary>
        [DisplayName("失败登录尝试次数")]
        [Description("失败登录尝试次数")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AccessFailedCount", "失败登录尝试次数", "")]
        public Int32 AccessFailedCount { get { return _AccessFailedCount; } set { if (OnPropertyChanging(__.AccessFailedCount, value)) { _AccessFailedCount = value; OnPropertyChanged(__.AccessFailedCount); } } }

        private Int32 _Sex;
        /// <summary>性别。未知-1、男1、女0</summary>
        [DisplayName("性别")]
        [Description("性别。未知-1、男1、女0")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Sex", "性别。未知-1、男1、女0", "")]
        public Int32 Sex { get { return _Sex; } set { if (OnPropertyChanging(__.Sex, value)) { _Sex = value; OnPropertyChanged(__.Sex); } } }

        private String _Code;
        /// <summary>代码。身份证、员工编号等</summary>
        [DisplayName("代码")]
        [Description("代码。身份证、员工编号等")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Code", "代码。身份证、员工编号等", "")]
        public String Code { get { return _Code; } set { if (OnPropertyChanging(__.Code, value)) { _Code = value; OnPropertyChanged(__.Code); } } }

        private String _Avatar;
        /// <summary>头像</summary>
        [DisplayName("头像")]
        [Description("头像")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("Avatar", "头像", "")]
        public String Avatar { get { return _Avatar; } set { if (OnPropertyChanging(__.Avatar, value)) { _Avatar = value; OnPropertyChanged(__.Avatar); } } }

        private Boolean _Online;
        /// <summary>在线</summary>
        [DisplayName("在线")]
        [Description("在线")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Online", "在线", "")]
        public Boolean Online { get { return _Online; } set { if (OnPropertyChanging(__.Online, value)) { _Online = value; OnPropertyChanged(__.Online); } } }

        private Boolean _Enable;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Enable", "启用", "")]
        public Boolean Enable { get { return _Enable; } set { if (OnPropertyChanging(__.Enable, value)) { _Enable = value; OnPropertyChanged(__.Enable); } } }

        private Int32 _Logins;
        /// <summary>登录次数</summary>
        [DisplayName("登录次数")]
        [Description("登录次数")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Logins", "登录次数", "")]
        public Int32 Logins { get { return _Logins; } set { if (OnPropertyChanging(__.Logins, value)) { _Logins = value; OnPropertyChanged(__.Logins); } } }

        private DateTime _LastLogin;
        /// <summary>最后登录</summary>
        [DisplayName("最后登录")]
        [Description("最后登录")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LastLogin", "最后登录", "")]
        public DateTime LastLogin { get { return _LastLogin; } set { if (OnPropertyChanging(__.LastLogin, value)) { _LastLogin = value; OnPropertyChanged(__.LastLogin); } } }

        private String _LastLoginIP;
        /// <summary>最后登录IP</summary>
        [DisplayName("最后登录IP")]
        [Description("最后登录IP")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("LastLoginIP", "最后登录IP", "")]
        public String LastLoginIP { get { return _LastLoginIP; } set { if (OnPropertyChanging(__.LastLoginIP, value)) { _LastLoginIP = value; OnPropertyChanged(__.LastLoginIP); } } }

        private DateTime _RegisterTime;
        /// <summary>注册时间</summary>
        [DisplayName("注册时间")]
        [Description("注册时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RegisterTime", "注册时间", "")]
        public DateTime RegisterTime { get { return _RegisterTime; } set { if (OnPropertyChanging(__.RegisterTime, value)) { _RegisterTime = value; OnPropertyChanged(__.RegisterTime); } } }

        private String _RegisterIP;
        /// <summary>注册IP</summary>
        [DisplayName("注册IP")]
        [Description("注册IP")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("RegisterIP", "注册IP", "")]
        public String RegisterIP { get { return _RegisterIP; } set { if (OnPropertyChanging(__.RegisterIP, value)) { _RegisterIP = value; OnPropertyChanged(__.RegisterIP); } } }
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
                    case __.UserName : return _UserName;
                    case __.NormalizedUserName : return _NormalizedUserName;
                    case __.Email : return _Email;
                    case __.NormalizedEmail : return _NormalizedEmail;
                    case __.EmailConfirmed : return _EmailConfirmed;
                    case __.PasswordHash : return _PasswordHash;
                    case __.SecurityStamp : return _SecurityStamp;
                    case __.ConcurrencyStamp : return _ConcurrencyStamp;
                    case __.PhoneNumber : return _PhoneNumber;
                    case __.PhoneNumberConfirmed : return _PhoneNumberConfirmed;
                    case __.TwoFactorEnabled : return _TwoFactorEnabled;
                    case __.LockoutEnd : return _LockoutEnd;
                    case __.LockoutEnabled : return _LockoutEnabled;
                    case __.AccessFailedCount : return _AccessFailedCount;
                    case __.Sex : return _Sex;
                    case __.Code : return _Code;
                    case __.Avatar : return _Avatar;
                    case __.Online : return _Online;
                    case __.Enable : return _Enable;
                    case __.Logins : return _Logins;
                    case __.LastLogin : return _LastLogin;
                    case __.LastLoginIP : return _LastLoginIP;
                    case __.RegisterTime : return _RegisterTime;
                    case __.RegisterIP : return _RegisterIP;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = value.ToInt(); break;
                    case __.UserName : _UserName = Convert.ToString(value); break;
                    case __.NormalizedUserName : _NormalizedUserName = Convert.ToString(value); break;
                    case __.Email : _Email = Convert.ToString(value); break;
                    case __.NormalizedEmail : _NormalizedEmail = Convert.ToString(value); break;
                    case __.EmailConfirmed : _EmailConfirmed = value.ToBoolean(); break;
                    case __.PasswordHash : _PasswordHash = Convert.ToString(value); break;
                    case __.SecurityStamp : _SecurityStamp = Convert.ToString(value); break;
                    case __.ConcurrencyStamp : _ConcurrencyStamp = Convert.ToString(value); break;
                    case __.PhoneNumber : _PhoneNumber = Convert.ToString(value); break;
                    case __.PhoneNumberConfirmed : _PhoneNumberConfirmed = value.ToBoolean(); break;
                    case __.TwoFactorEnabled : _TwoFactorEnabled = value.ToBoolean(); break;
                    case __.LockoutEnd : _LockoutEnd = value.ToDateTime(); break;
                    case __.LockoutEnabled : _LockoutEnabled = value.ToBoolean(); break;
                    case __.AccessFailedCount : _AccessFailedCount = value.ToInt(); break;
                    case __.Sex : _Sex = value.ToInt(); break;
                    case __.Code : _Code = Convert.ToString(value); break;
                    case __.Avatar : _Avatar = Convert.ToString(value); break;
                    case __.Online : _Online = value.ToBoolean(); break;
                    case __.Enable : _Enable = value.ToBoolean(); break;
                    case __.Logins : _Logins = value.ToInt(); break;
                    case __.LastLogin : _LastLogin = value.ToDateTime(); break;
                    case __.LastLoginIP : _LastLoginIP = Convert.ToString(value); break;
                    case __.RegisterTime : _RegisterTime = value.ToDateTime(); break;
                    case __.RegisterIP : _RegisterIP = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityUser字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>名称。登录用户名</summary>
            public static readonly Field UserName = FindByName(__.UserName);

            /// <summary>友好显示名</summary>
            public static readonly Field NormalizedUserName = FindByName(__.NormalizedUserName);

            /// <summary>邮件</summary>
            public static readonly Field Email = FindByName(__.Email);

            /// <summary>规范化的邮件</summary>
            public static readonly Field NormalizedEmail = FindByName(__.NormalizedEmail);

            /// <summary>邮箱验证(指示用户是否已验证其邮箱)</summary>
            public static readonly Field EmailConfirmed = FindByName(__.EmailConfirmed);

            /// <summary>密码哈希(获取或设置此用户密码的salt和hash表示形式)</summary>
            public static readonly Field PasswordHash = FindByName(__.PasswordHash);

            /// <summary>凭据随机值(当用户凭据更改时必须更改的随机值,比如更改密码、删除登录名)</summary>
            public static readonly Field SecurityStamp = FindByName(__.SecurityStamp);

            /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
            public static readonly Field ConcurrencyStamp = FindByName(__.ConcurrencyStamp);

            /// <summary>手机号</summary>
            public static readonly Field PhoneNumber = FindByName(__.PhoneNumber);

            /// <summary>手机号验证(指示用户是否已验证其手机号)</summary>
            public static readonly Field PhoneNumberConfirmed = FindByName(__.PhoneNumberConfirmed);

            /// <summary>双重验证(指示是否为此用户启用了双重身份验证)</summary>
            public static readonly Field TwoFactorEnabled = FindByName(__.TwoFactorEnabled);

            /// <summary>最后锁定时间</summary>
            public static readonly Field LockoutEnd = FindByName(__.LockoutEnd);

            /// <summary>启用锁定</summary>
            public static readonly Field LockoutEnabled = FindByName(__.LockoutEnabled);

            /// <summary>失败登录尝试次数</summary>
            public static readonly Field AccessFailedCount = FindByName(__.AccessFailedCount);

            /// <summary>性别。未知-1、男1、女0</summary>
            public static readonly Field Sex = FindByName(__.Sex);

            /// <summary>代码。身份证、员工编号等</summary>
            public static readonly Field Code = FindByName(__.Code);

            /// <summary>头像</summary>
            public static readonly Field Avatar = FindByName(__.Avatar);

            /// <summary>在线</summary>
            public static readonly Field Online = FindByName(__.Online);

            /// <summary>启用</summary>
            public static readonly Field Enable = FindByName(__.Enable);

            /// <summary>登录次数</summary>
            public static readonly Field Logins = FindByName(__.Logins);

            /// <summary>最后登录</summary>
            public static readonly Field LastLogin = FindByName(__.LastLogin);

            /// <summary>最后登录IP</summary>
            public static readonly Field LastLoginIP = FindByName(__.LastLoginIP);

            /// <summary>注册时间</summary>
            public static readonly Field RegisterTime = FindByName(__.RegisterTime);

            /// <summary>注册IP</summary>
            public static readonly Field RegisterIP = FindByName(__.RegisterIP);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得IdentityUser字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>名称。登录用户名</summary>
            public const String UserName = "UserName";

            /// <summary>友好显示名</summary>
            public const String NormalizedUserName = "NormalizedUserName";

            /// <summary>邮件</summary>
            public const String Email = "Email";

            /// <summary>规范化的邮件</summary>
            public const String NormalizedEmail = "NormalizedEmail";

            /// <summary>邮箱验证(指示用户是否已验证其邮箱)</summary>
            public const String EmailConfirmed = "EmailConfirmed";

            /// <summary>密码哈希(获取或设置此用户密码的salt和hash表示形式)</summary>
            public const String PasswordHash = "PasswordHash";

            /// <summary>凭据随机值(当用户凭据更改时必须更改的随机值,比如更改密码、删除登录名)</summary>
            public const String SecurityStamp = "SecurityStamp";

            /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
            public const String ConcurrencyStamp = "ConcurrencyStamp";

            /// <summary>手机号</summary>
            public const String PhoneNumber = "PhoneNumber";

            /// <summary>手机号验证(指示用户是否已验证其手机号)</summary>
            public const String PhoneNumberConfirmed = "PhoneNumberConfirmed";

            /// <summary>双重验证(指示是否为此用户启用了双重身份验证)</summary>
            public const String TwoFactorEnabled = "TwoFactorEnabled";

            /// <summary>最后锁定时间</summary>
            public const String LockoutEnd = "LockoutEnd";

            /// <summary>启用锁定</summary>
            public const String LockoutEnabled = "LockoutEnabled";

            /// <summary>失败登录尝试次数</summary>
            public const String AccessFailedCount = "AccessFailedCount";

            /// <summary>性别。未知-1、男1、女0</summary>
            public const String Sex = "Sex";

            /// <summary>代码。身份证、员工编号等</summary>
            public const String Code = "Code";

            /// <summary>头像</summary>
            public const String Avatar = "Avatar";

            /// <summary>在线</summary>
            public const String Online = "Online";

            /// <summary>启用</summary>
            public const String Enable = "Enable";

            /// <summary>登录次数</summary>
            public const String Logins = "Logins";

            /// <summary>最后登录</summary>
            public const String LastLogin = "LastLogin";

            /// <summary>最后登录IP</summary>
            public const String LastLoginIP = "LastLoginIP";

            /// <summary>注册时间</summary>
            public const String RegisterTime = "RegisterTime";

            /// <summary>注册IP</summary>
            public const String RegisterIP = "RegisterIP";
        }
        #endregion
    }

    /// <summary>IdentityUser(用户)接口</summary>
    public partial interface IIdentityUser
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>名称。登录用户名</summary>
        String UserName { get; set; }

        /// <summary>友好显示名</summary>
        String NormalizedUserName { get; set; }

        /// <summary>邮件</summary>
        String Email { get; set; }

        /// <summary>规范化的邮件</summary>
        String NormalizedEmail { get; set; }

        /// <summary>邮箱验证(指示用户是否已验证其邮箱)</summary>
        Boolean EmailConfirmed { get; set; }

        /// <summary>密码哈希(获取或设置此用户密码的salt和hash表示形式)</summary>
        String PasswordHash { get; set; }

        /// <summary>凭据随机值(当用户凭据更改时必须更改的随机值,比如更改密码、删除登录名)</summary>
        String SecurityStamp { get; set; }

        /// <summary>存储随机值(当用户被持久化到存储时必须更改的随机值)</summary>
        String ConcurrencyStamp { get; set; }

        /// <summary>手机号</summary>
        String PhoneNumber { get; set; }

        /// <summary>手机号验证(指示用户是否已验证其手机号)</summary>
        Boolean PhoneNumberConfirmed { get; set; }

        /// <summary>双重验证(指示是否为此用户启用了双重身份验证)</summary>
        Boolean TwoFactorEnabled { get; set; }

        /// <summary>最后锁定时间</summary>
        DateTime LockoutEnd { get; set; }

        /// <summary>启用锁定</summary>
        Boolean LockoutEnabled { get; set; }

        /// <summary>失败登录尝试次数</summary>
        Int32 AccessFailedCount { get; set; }

        /// <summary>性别。未知-1、男1、女0</summary>
        Int32 Sex { get; set; }

        /// <summary>代码。身份证、员工编号等</summary>
        String Code { get; set; }

        /// <summary>头像</summary>
        String Avatar { get; set; }

        /// <summary>在线</summary>
        Boolean Online { get; set; }

        /// <summary>启用</summary>
        Boolean Enable { get; set; }

        /// <summary>登录次数</summary>
        Int32 Logins { get; set; }

        /// <summary>最后登录</summary>
        DateTime LastLogin { get; set; }

        /// <summary>最后登录IP</summary>
        String LastLoginIP { get; set; }

        /// <summary>注册时间</summary>
        DateTime RegisterTime { get; set; }

        /// <summary>注册IP</summary>
        String RegisterIP { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}