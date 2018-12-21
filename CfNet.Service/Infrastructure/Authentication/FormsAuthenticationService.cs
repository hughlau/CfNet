using System;
using System.Web;
using System.Web.Security;
using CfNet.Core.Domain.SysUser;
using CfNet.Service.SysUserService;


/****************************************************************
*   Author：L
*   Time：2018/12/21 15:37:15
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.Infrastructure.Authentication
{
    public partial class FormsAuthenticationService : IAuthenticationService
    {

        #region =============属性============

        private readonly HttpContextBase _httpContext;
        private readonly ISysUserService _userService;
        private readonly ISysUserAuthService _userAuthService;
        private readonly TimeSpan _expirationTimeSpan;

        private SysUser _cachedUser;
        #endregion

        #region ===========构造函数==========

        public FormsAuthenticationService(HttpContextBase httpContext,
            ISysUserService userService, ISysUserAuthService userAuthService)
        {
            this._httpContext = httpContext;
            this._userService = userService;
            this._userAuthService = userAuthService;
            this._expirationTimeSpan = FormsAuthentication.Timeout;
        }

        #endregion

        #region ===========基本方法==========

        protected virtual SysUser GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            var userTicket = ticket.UserData;
            SysUser user = _userService.Get(int.Parse(userTicket));
            return user;
        }

        #endregion

        #region =============方法============

        public SysUser GetAuthenticatedUser()
        {
            if (_cachedUser != null)
                return _cachedUser;

            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;
            var user = GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);
            if (_cachedUser != null)
                _cachedUser = user;
            return _cachedUser;
        }

        public void SignIn(SysUser user, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                user.UserName,
                now,
                now.Add(_expirationTimeSpan),
                createPersistentCookie,
                user.UserID.ToString(),
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpContext.Response.Cookies.Add(cookie);
            _cachedUser = user;
        }

        public void SignOut()
        {
            _cachedUser = null;
            FormsAuthentication.SignOut();
        }

        #endregion

    }
}
