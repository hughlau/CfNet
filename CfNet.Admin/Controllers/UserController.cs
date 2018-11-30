using CfNet.Admin.ModelFactories;
using CfNet.Admin.Models.SysUser;
using CfNet.Core.Domain.Dict;
using CfNet.Core.Domain.SysUser;
using CfNet.Core.Infrastructure;
using CfNet.Service.SysUserService;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfNet.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly ISysUserService _sysUserService;
        private readonly ISysUserAuthService _sysUserAuthService;
        private readonly ISysUserModelFactory _modelFactory;

        public UserController(ISysUserService sysUserService,ISysUserAuthService sysUserAuthService
            ,ISysUserModelFactory modelFactory)
        {
            this._sysUserService = sysUserService;
            this._sysUserAuthService = sysUserAuthService;
            this._modelFactory = modelFactory;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            SysUserEditModel model = null;
            if (id!=0)
            {
                IList<IPredicate> predList = new List<IPredicate>();
                predList.Add(Predicates.Field<SysUserAuth>(p => p.AuthType, Operator.Eq, (int)DictSysUserAuth.loginname));
                predList.Add(Predicates.Field<SysUserAuth>(p => p.UserId, Operator.Eq, id));
                IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());

                SysUser sysUser = _sysUserService.Get(id);
                SysUserAuth userAuth = _sysUserAuthService.GetFirstOrDefault(predGroup);

                model = _modelFactory.PrepareUser(sysUser, userAuth);
            }
            else
            {
                model = new SysUserEditModel();
            }
            return View(model);
        }

        public ActionResult te()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PageData(int pageNumber, int pageSize,string sort,string sortOrder
            ,string userName,string mobile,string slExist)
        {
            IList<ISort> sorts = new List<ISort>();
            ISort isort = new Sort();
            if (String.IsNullOrEmpty(sort))
            {
                isort.PropertyName = "CreateTime";
                isort.Ascending = false;
            }
            else
            {
                isort.PropertyName = sort;
                isort.Ascending = sortOrder.ToLower()=="asc";
            }
            sorts.Add(isort);

            pageNumber--;

            IList<IPredicate> predList = new List<IPredicate>();
            if (!String.IsNullOrEmpty(userName))
            {
                predList.Add(Predicates.Field<SysUser>(p => p.UserName, Operator.Like, "%"+userName+"%"));
            }
            if (!String.IsNullOrEmpty(mobile))
            {
                predList.Add(Predicates.Field<SysUser>(p => p.Mobile, Operator.Like, "%" + mobile + "%"));
            }
            if (!String.IsNullOrEmpty(slExist) && slExist!="2")
            {
                predList.Add(Predicates.Field<SysUser>(p => p.IsExist, Operator.Eq, int.Parse(slExist)));
            }
            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());

            PageDataView<SysUser> result = _sysUserService.GetPageView(predGroup, pageNumber, pageSize,sorts);
            return new JsonResult() {
                Data = result
            };
        }
    }
}