using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;

namespace Extensions.Identity.Stores.XCode
{
    /// <summary>IdentityUser</summary>
    [Serializable]
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class IdentityUser : IdentityUser<IdentityUser> { }

    /// <summary>IdentityUser(用户)</summary>
    public partial class IdentityUser<TEntity> : Entity<TEntity> where TEntity : IdentityUser<TEntity>, new()
    {
        #region 对象操作
        static IdentityUser()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            var entity = new TEntity();

            // 累加字段
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(__.AccessFailedCount);

            // 过滤器 UserModule、TimeModule、IPModule

            // 单对象缓存
            var sc = Meta.SingleCache;
            sc.FindSlaveKeyMethod = k => Find(__.UserName, k);
            sc.GetSlaveKeyMethod = e => e.UserName;
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (UserName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(UserName), "名称不能为空！");
            if (NormalizedUserName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(NormalizedUserName), "友好显示名不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正

            // 检查唯一索引
            // CheckExist(isNew, __.UserName);
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TEntity[IdentityUser]数据……");

        //    var entity = new TEntity();
        //    entity.Id = 0;
        //    entity.UserName = "abc";
        //    entity.NormalizedUserName = "abc";
        //    entity.Email = "abc";
        //    entity.NormalizedEmail = "abc";
        //    entity.EmailConfirmed = true;
        //    entity.PasswordHash = "abc";
        //    entity.SecurityStamp = "abc";
        //    entity.ConcurrencyStamp = "abc";
        //    entity.PhoneNumber = "abc";
        //    entity.PhoneNumberConfirmed = true;
        //    entity.TwoFactorEnabled = true;
        //    entity.LockoutEnd = DateTime.Now;
        //    entity.LockoutEnabled = true;
        //    entity.AccessFailedCount = 0;
        //    entity.Sex = 0;
        //    entity.Code = "abc";
        //    entity.Avatar = "abc";
        //    entity.Online = true;
        //    entity.Enable = true;
        //    entity.Logins = 0;
        //    entity.LastLogin = DateTime.Now;
        //    entity.LastLoginIP = "abc";
        //    entity.RegisterTime = DateTime.Now;
        //    entity.RegisterIP = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TEntity[IdentityUser]数据！");
        //}

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnDelete()
        //{
        //    return base.OnDelete();
        //}
        #endregion

        #region 扩展属性
        public DateTimeOffset? LockoutEndOffset
        {
            get => LockoutEnd > DateTime.MinValue ? new DateTimeOffset?(LockoutEnd) : null;
            set
            {
                if (value.HasValue)
                {
                    LockoutEnd = value.Value.DateTime;
                }
            }
        }

        #endregion

        #region 扩展查询
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns>实体对象</returns>
        public static TEntity FindById(Int32 id)
        {
            if (id <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Id == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.Id == id);
        }

        /// <summary>根据名称查找</summary>
        /// <param name="username">名称</param>
        /// <returns>实体对象</returns>
        public static TEntity FindByUserName(String username)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.UserName == username);

            // 单对象缓存
            //return Meta.SingleCache.GetItemWithSlaveKey(username) as TEntity;

            return Find(_.UserName == username);
        }

        /// <summary>根据名称查找</summary>
        /// <param name="normalizedUserName">名称</param>
        /// <returns>实体对象</returns>
        public static TEntity FindByNormalizedUserName(String normalizedUserName)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.NormalizedUserName == normalizedUserName);

            // 单对象缓存
            //return Meta.SingleCache.GetItemWithSlaveKey(username) as TEntity;

            return Find(_.NormalizedUserName == normalizedUserName);
        }

        /// <summary>根据邮件查找</summary>
        /// <param name="email">邮件</param>
        /// <returns>实体列表</returns>
        public static IList<TEntity> FindAllByEmail(String email)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Email == email);

            return FindAll(_.Email == email);
        }

        /// <summary>根据邮件查找</summary>
        /// <param name="normalizedEmail">邮件</param>
        /// <returns>实体列表</returns>
        public static TEntity FindByNormalizedEmail(String normalizedEmail)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.NormalizedEmail == normalizedEmail);

            return Find(_.Email == normalizedEmail);
        }

        /// <summary>根据手机号查找</summary>
        /// <param name="phonenumber">手机号</param>
        /// <returns>实体列表</returns>
        public static IList<TEntity> FindAllByPhoneNumber(String phonenumber)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.PhoneNumber == phonenumber);

            return FindAll(_.PhoneNumber == phonenumber);
        }

        /// <summary>根据id列表查找</summary>
        /// <param name="ids"></param>
        /// <returns>实体列表</returns>
        public static IList<TEntity> FindAllByIds(List<int> ids)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => ids.Contains(e.Id));

            return FindAll(_.Id.In(ids));
        }
        #endregion

        #region 高级查询
        #endregion

        #region 业务操作
        #endregion
    }
}