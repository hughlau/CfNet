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
            return View();
        }

        [HttpPost]
        public ActionResult MenuData()
        {
            List<SysMenu> sysMenus = _sysMenuService.GetAll().ToList<SysMenu>();
            return new JsonResult()
            {
                Data = sysMenus
            };
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SysMenuEditModel model = null;
            if (id != 0)
            {
                SysMenu menu = _sysMenuService.Get(id);
                model = new SysMenuEditModel()
                {
                    MenuName = menu.MenuName,
                    Status = menu.Status == 0,
                    Url = menu.Url,
                    MenuId = menu.MenuId
                };
            }
            else
            {
                model = new SysMenuEditModel();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SysMenuEditModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.MenuId != 0)
                {
                    UpdateMenu(model);
                }
                else
                {
                    AddMenu(model);
                }
                return Content("success");
                
            }
            return Content("");
        }

        private void UpdateMenu(SysMenuEditModel model)
        {
            SysMenu sysMenu = _sysMenuService.Get(model.MenuId);
            sysMenu.MenuName = model.MenuName;
            sysMenu.Url = model.Url;
            sysMenu.Status = model.Status ? 0 : 1;
            sysMenu.UpdateTime = DateTime.Now.ToShortDateString();
            _sysMenuService.Update(sysMenu);
        }

        private void AddMenu(SysMenuEditModel model)
        {
            SysMenu sysMenu = new SysMenu()
            {
                MenuName = model.MenuName,
                Url = model.Url,
                Status = model.Status ? 0 : 1
            };
            _sysMenuService.Add(sysMenu);
        }
    }
}