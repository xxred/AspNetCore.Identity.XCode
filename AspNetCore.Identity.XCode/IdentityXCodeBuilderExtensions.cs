using System;
using System.Reflection;
using Extensions.Identity.Stores.XCode;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetCore.Identity.XCode
{
    /// <summary>
    /// Contains extension methods to <see cref="IdentityBuilder"/> for adding xcode stores.
    /// </summary>
    public static class IdentityXCodeBuilderExtensions
    {
        /// <summary>
        /// Adds an XCode implementation of identity information stores.
        /// </summary>
        /// <param name="builder">The <see cref="IdentityBuilder"/> instance this method extends.</param>
        /// <returns>The <see cref="IdentityBuilder"/> instance this method extends.</returns>
        public static IdentityBuilder AddXCodeStores(this IdentityBuilder builder)
        {
            AddStores(builder.Services, builder.UserType, builder.RoleType);
            return builder;
        }

        /// <summary>
        /// Adds an XCode implementation of identity.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IdentityBuilder AddIdentityXCode<TUser, TRole>(this IServiceCollection services)
        where TUser : IdentityUser<TUser>, new()
        where TRole : IdentityRole<TRole>, new()
        {
            return services.AddIdentityCore<TUser>()
                .AddRoles<TRole>()
                .AddXCodeStores()
                .AddSignInManager()
                .AddDefaultTokenProviders();
        }

        /// <summary>
        /// Adds an XCode implementation of identity.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IdentityBuilder AddIdentityXCode(this IServiceCollection services)
        {
            return services.AddIdentityXCode<IdentityUser, IdentityRole>();
        }

        private static void AddStores(IServiceCollection services, Type userType, Type roleType)
        {
            var identityUserType = FindGenericBaseType(userType, typeof(IdentityUser<>));
            if (identityUserType == null)
            {
                throw new InvalidOperationException("只能使用从IdentityUser<TEntity>派生的用户调用AddXCodeStores");
            }

            if (roleType != null)
            {
                var identityRoleType = FindGenericBaseType(roleType, typeof(IdentityRole<>));
                if (identityRoleType == null)
                {
                    throw new InvalidOperationException("只能使用从IdentityRole<TEntity>派生的角色调用AddXCodeStores");
                }

                var userStoreType = typeof(UserStore<>).MakeGenericType(userType);
                var roleStoreType = typeof(RoleStore<>).MakeGenericType(roleType);

                services.TryAddScoped(typeof(IUserStore<>).MakeGenericType(userType), userStoreType);
                services.TryAddScoped(typeof(IRoleStore<>).MakeGenericType(roleType), roleStoreType);
            }
            else
            {   // No Roles
                var userStoreType = typeof(UserStore<>).MakeGenericType(userType);


                services.TryAddScoped(typeof(IUserStore<>).MakeGenericType(userType), userStoreType);
            }

        }

        private static TypeInfo FindGenericBaseType(Type currentType, Type genericBaseType)
        {
            var type = currentType;
            while (type != null)
            {
                var typeInfo = type.GetTypeInfo();
                var genericType = type.IsGenericType ? type.GetGenericTypeDefinition() : null;
                if (genericType != null && genericType == genericBaseType)
                {
                    return typeInfo;
                }
                type = type.BaseType;
            }
            return null;
        }
    }
}