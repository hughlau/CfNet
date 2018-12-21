using CfNet.Core.Domain;
using CfNet.Service.SysMenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ActionResult Menu()
        {
            IList<SysMenu> sysMenus = _sysMenuService.GetAll().ToList<SysMenu>();
            string menusString = GetMenuString(sysMenus, new StringBuilder(), 0);
            ViewData.Add("menus", menusString);
            return PartialView();
        }


        public string GetMenuString(IList<SysMenu> menus,StringBuilder htmlString,int parentId)
        {
            IList<SysMenu> thisLevelMenus = menus.Where(p => p.ParentID == parentId).ToList();
            if (parentId!=0)
            {
                htmlString.Append("<ul class=\"treeview-menu\">");
            }
            foreach (var menu in thisLevelMenus)
            {
                if ("<ul>".Equals(htmlString.ToString()))
                {
                    htmlString.Append("<li class=\"treeview active\">");
                }
                else
                {
                    htmlString.Append("<li class=\"treeview\">");
                }
                if (parentId==0)
                {
                    htmlString.Append("<a href=\"#\">");
                    htmlString.Append("<i class=\"fa fa-desktop\"></i><span>" + menu.MenuName + "</span><i class=\"fa fa-angle-left pull-right\"></i>");
                    htmlString.Append("</a>");
                }
                else
                {
                    htmlString.Append("<a class=\"menuItem\" data-id=\""+menu.MenuId+"\" href=\""+menu.Url+"\">");
                    htmlString.Append("<i class=\"fa fa-sitemap\"></i>"+menu.MenuName+"</a>");
                }
                IList<SysMenu> nextLevelMenus = menus.Where(p => p.ParentID == menu.MenuId).ToList();
                if (nextLevelMenus!=null && nextLevelMenus.Count>0)
                {
                    htmlString.Append(GetMenuString(menus, new StringBuilder(), menu.MenuId));
                }
                htmlString.Append("</li>");
            }
            htmlString.Append("</ul>");
            return htmlString.ToString();
            
        }
    }
}