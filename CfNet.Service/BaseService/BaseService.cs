using CfNet.Core.Infrastructure;
using CfNet.Data.Infrastructure;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/27 17:20:52
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.BaseService
{
    public class BaseService<T>:IBaseService<T> where T:class,new()
    {
        #region Field

        private readonly IRepository<T> _repository;

        #endregion

        #region Ctor

        public BaseService(IRepository<T> repository)
        {
            this._repository = repository;
        }

        #endregion

        #region Method

        public IList<T> GetAll()
        {
            try
            {
                return _repository.GetModels(null);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PageDataView<T> GetPageView(IPredicateGroup predicateGroup,int pageIndex,int pageSize,IList<ISort> sorts)
        {
            try
            {
                PageDataView<T> page = new PageDataView<T>();
                page.total = GetCount(predicateGroup);
                IList<T> ts= _repository.GetModelByPage(predicateGroup, pageIndex, pageSize,sorts);
                page.rows = ts;
                page.CurrentPage = pageIndex;
                page.TotalPageCount = (page.total % pageSize) == 0 ? page.total / pageSize : ((int)Math.Floor((double)(page.total / pageSize)) + 1);
                return page;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCount(IPredicateGroup predicateGroup)
        {
            try
            {
                return _repository.Count(predicateGroup);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
