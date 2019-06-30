using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCore.Identity.XCode
{
    /// <summary>
    /// 自定义登录管理器，主要是修改Schema
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    class CustomSignInManager<TUser>: SignInManager<TUser> where TUser : class
    {
        public CustomSignInManager(UserManager<TUser> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<TUser> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<TUser>> logger, 
            IAuthenticationSchemeProvider schemes) : 
            base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }


    }
}
