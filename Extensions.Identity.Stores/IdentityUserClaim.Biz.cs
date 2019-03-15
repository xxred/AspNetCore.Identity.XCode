using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
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
    /// <summary>IdentityUserClaim</summary>
    [Serializable]
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class IdentityUserClaim : IdentityUserClaim<IdentityUserClaim> { }

    /// <summary>IdentityUserClaim(用户声明集合)</summary>
    public partial class IdentityUserClaim<TEntity> : Entity<TEntity> where TEntity : IdentityUserClaim<TEntity>, new()
    {
        #region 对象操作
        static IdentityUserClaim()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            var entity = new TEntity();

            // 累加字段
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(__.UserId);

            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>
        /// 通过 type 和 value实例化一个新的声明claim
        /// </summary>
        /// <returns></returns>
        public virtual Claim ToClaim()
        {
            return new Claim(ClaimType, ClaimValue);
        }

        /// <summary>
        /// 通过从其它声明claim复制ClaimType 和 ClaimValue 来初始化
        /// </summary>
        /// <param name="other">The claim to initialize from.</param>
        public virtual void InitializeFromClaim(Claim other)
        {
            ClaimType = other?.Type;
            ClaimValue = other?.Value;
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (ClaimType.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ClaimType), "声明类型不能为空！");
            if (ClaimValue.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ClaimValue), "声明值不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TEntity[IdentityUserClaim]数据……");

        //    var entity = new TEntity();
        //    entity.Id = 0;
        //    entity.UserId = 0;
        //    entity.ClaimType = "abc";
        //    entity.ClaimValue = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TEntity[IdentityUserClaim]数据！");
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

        /// <summary>根据用户编号查找</summary>
        /// <param name="userid">用户编号</param>
        /// <returns>实体列表</returns>
        public static IList<TEntity> FindAllByUserId(Int32 userid)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.UserId == userid);

            return FindAll(_.UserId == userid);
        }

        /// <summary>根据用户编号、声明类型和值查找</summary>
        /// <param name="userid">用户编号</param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns>实体列表</returns>
        public static IList<TEntity> FindAllByUserIdAndTypeAndValue(Int32 userid, String value, String type)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.UserId == userid && e.ClaimType == type && e.ClaimValue == value);

            return FindAll(_.UserId == userid & _.ClaimType == type & _.ClaimValue == value);
        }

        /// <summary>根据声明类型和值查找</summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns>实体列表</returns>
        public static IList<TEntity> FindAllByTypeAndValue(String type, String value)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.ClaimType == type && e.ClaimValue == value);

            return FindAll(_.ClaimType == type & _.ClaimValue == value);
        }
        #endregion

        #region 高级查询
        #endregion

        #region 业务操作
        #endregion
    }
}