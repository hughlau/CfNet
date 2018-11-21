using CfNet.Core.Domain;
using CfNet.Service.SysMenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfNet.Admin.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISysMenuService _sysMenuService;

        public HomeController(ISysMenuService sysMenuService)
        {
            this._sysMenuService = sysMenuService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            IList<SysMenu> sysMenus= _sysMenuService.GetAll().ToList<SysMenu>();


            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}