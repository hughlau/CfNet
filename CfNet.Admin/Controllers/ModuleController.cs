using CfNet.Admin.Models.Menu;
using CfNet.Core.Domain;
using CfNet.Core.Infrastructure;
using CfNet.Service.SysMenuService;
using DapperExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfNet.Admin.Controllers
{
    public class ModuleController : Controller
    {
        private readonly ISysMenuService _sysMenuService;
        private readonly ISysPageService _sysPageService;

        public ModuleController(ISysMenuService sysMenuService, ISysPageService sysPageService)
        {
            this._sysMenuService = sysMenuService;
            this._sysPageService = sysPageService;
        }

        // GET: Module
        public ActionResult Index()
        {
            List<SysMenu> sysMenus = _sysMenuService.GetAll().ToList<SysMenu>();
            dynamic ls = sysMenus.Select(p => new { id = p.MenuId, name = p.MenuName, pId = p.ParentID }).ToList();
            string treeJson = JsonConvert.SerializeObject(ls);
            ViewBag.tree = treeJson;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int pageid,int menuid)
        {
            if (0!= pageid)
            {
                ViewBag.Title = "编辑信息";
                PageModel model = null;
                if (pageid != 0)
                {
                    SysPage page = _sysPageService.Get(pageid);
                    model = new PageModel()
                    {
                        MenuId = page.MenuId,
                        PageId = page.PageId,
                        PageName = page.PageName,
                        Description = page.Description,
                        IsValid = page.IsValid == 0,
                        Url = page.Url
                    };
                }
                else
                {
                    model = new PageModel();
                }
                return View(model);
            }
            else
            {
                ViewBag.menuid = menuid;
                ViewBag.Title = "添加信息";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(PageModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.PageId != 0)
                {
                    UpdatePage(model);
                }
                else
                {
                    AddPage(model);
                }
                return Content("success");
            }
            return Content("");

        }

        [HttpPost]
        public JsonResult PageData(int pageNumber, int pageSize, string sort, string sortOrder , int id)
        {
            IList<ISort> sorts = new List<ISort>();
            ISort isort = new Sort();
            if (String.IsNullOrEmpty(sort))
            {
                isort.PropertyName = "CreateTime";
                isort.Ascending = false;
            }
            sorts.Add(isort);

            pageNumber--;

            IList<IPredicate> predList = new List<IPredicate>();
            predList.Add(Predicates.Field<SysPage>(p => p.MenuId, Operator.Eq,id));
            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());

            PageDataView<SysPage> result = _sysPageService.GetPageView(predGroup, pageNumber, pageSize, sorts);
            return new JsonResult()
            {
                Data = result
            };
        }

        public void UpdatePage(PageModel model)
        {
            SysPage page = _sysPageService.Get(model.PageId);
            page.PageName = model.PageName;
            page.IsValid = model.IsValid?0:1;
            page.Url = model.Url;
            page.Description = model.Description;
            _sysPageService.Update(page);
        }

        public void AddPage (PageModel model)
        {
            SysPage page = new SysPage()
            {
                MenuId = model.MenuId,
                IsValid = model.IsValid ? 0 : 1,
                Description = model.Description,
                PageName = model.PageName,
                Url = model.Url
            };
            _sysPageService.Add(page);
        }
    }
}