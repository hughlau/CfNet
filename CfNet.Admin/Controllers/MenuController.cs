using CfNet.Admin.Models.Menu;
using CfNet.Core.Domain;
using CfNet.Service.SysMenuService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfNet.Admin.Controllers
{
    public class MenuController : Controller
    {

        private readonly ISysMenuService _sysMenuService;

        public MenuController(ISysMenuService sysMenuService)
        {
            this._sysMenuService = sysMenuService;
        }

        public ActionResult Index()
        {
            List<SysMenu> sysMenus=_sysMenuService.GetAll().ToList<SysMenu>();
            string treeJson=JsonConvert.SerializeObject(sysMenus);
            ViewBag.Tree = treeJson;
            return View();
        }
    }
}