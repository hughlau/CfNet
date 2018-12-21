using CfNet.Admin.Models.Auth;
using CfNet.Core.Domain.SysUser;
using CfNet.Service.Infrastructure.Authentication;
using CfNet.Service.SysUserService;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfNet.Admin.Controllers
{
    public class AuthController : Controller
    {
        private readonly ISysUserService _sysUserService;
        private readonly ISysUserAuthService _sysUserAuthService;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IAuthenticationService _authenticationService;

        public AuthController(ISysUserService sysUserService, ISysUserAuthService sysUserAuthService
            ,IUserRegistrationService userRegistrationService,IAuthenticationService authenticationService)
        {
            this._sysUserAuthService = sysUserAuthService;
            this._sysUserService = sysUserService;
            this._userRegistrationService = userRegistrationService;
            this._authenticationService = authenticationService;
        }

        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var loginResult = _userRegistrationService.ValidateUser(loginModel.Username, loginModel.Password);
            switch (loginResult)
            {
                case UserLoginResults.Successful:
                    {
                        IPredicate predicate1 = Predicates.Field<SysUserAuth>(p => p.Openid, Operator.Eq, loginModel.Username);
                        IPredicate predicate2 = Predicates.Field<SysUserAuth>(p => p.AccessToken, Operator.Eq, loginModel.Password);
                        IPredicateGroup group1 = Predicates.Group(GroupOperator.And, predicate1, predicate2);
                        SysUserAuth userAuth1 = _sysUserAuthService.GetFirstOrDefault(group1);
                        SysUser user = _sysUserService.Get(userAuth1.UserId);
                        _authenticationService.SignIn(user, loginModel.RememberMe);
                        return Redirect("~/Home/Index");
                    }
                case UserLoginResults.UserNotExist:
                    {
                        loginModel.Message = "用户不存在";
                    }
                    break;
                case UserLoginResults.WrongPassword:
                    {
                        loginModel.Message = "密码错误";
                    }
                    break;
                default:
                    break;
            }
            return View(loginModel);
        }
    }
}