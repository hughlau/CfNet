using CfNet.Core.Domain.Base;
using CfNet.Core.Infrastructure;
using CfNet.Data.Infrastructure;
using DapperExtensions;
using System;
using System.Collections.Generic;

/****************************************************************
*   Author：L
*   Time：2018/11/27 17:20:52
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.BaseService
{
    public class BaseService<T>:IBaseService<T> where T: BaseEntity, new()
    {
        #region Field

        protected readonly IRepository<T> _repository;

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
            return _repository.GetModels(null);
        }

        public PageDataView<T> GetPageView(IPredicateGroup predicateGroup,int pageIndex,int pageSize,IList<ISort> sorts)
        {
            PageDataView<T> page = new PageDataView<T>();
            page.total = GetCount(predicateGroup);
            IList<T> ts = _repository.GetModelByPage(predicateGroup, pageIndex, pageSize, sorts);
            page.rows = ts;
            page.CurrentPage = pageIndex;
            page.TotalPageCount = (page.total % pageSize) == 0 ? page.total / pageSize : ((int)Math.Floor((double)(page.total / pageSize)) + 1);
            return page;
        }

        public int GetCount(IPredicateGroup predicateGroup)
        {
            return _repository.Count(predicateGroup);
        }

        public T Get(int id)
        {
            return _repository.GetModelByMainKey(id);
        }

        public T GetFirstOrDefault(IPredicateGroup predicateGroup)
        {
            return _repository.GetFirstOrDefault(predicateGroup);
        }

        public int Add(T t)
        {
            return (int)_repository.Insert(t);
        }

        public void Update(T t)
        {
            _repository.Update(t);
        }
        #endregion
    }
}
