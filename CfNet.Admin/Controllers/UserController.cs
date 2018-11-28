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

        public UserController(ISysUserService sysUserService)
        {
            this._sysUserService = sysUserService;
        }

        // GET: User
        public ActionResult Index()
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