using CfNet.Core.Domain.SysUser;
using CfNet.Service.Infrastructure.Authentication;
using System.Web.Mvc;

namespace CfNet.Admin.Controllers
{
    public class CommonController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public CommonController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            SysUser user= _authenticationService.GetAuthenticatedUser();
            ViewData.Add("username", user.UserName);
            return PartialView();
        }
    }
}