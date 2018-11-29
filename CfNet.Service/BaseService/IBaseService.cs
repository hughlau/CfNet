using CfNet.Core.Domain.Base;
using CfNet.Core.Infrastructure;
using DapperExtensions;
using System.Collections.Generic;

/****************************************************************
*   Author：L
*   Time：2018/11/27 17:20:41
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.BaseService
{
    public interface IBaseService<T> where T:BaseEntity,new()
    {

        #region Method

        IList<T> GetAll();

        PageDataView<T> GetPageView(IPredicateGroup predicateGroup, int pageIndex, int pageSize, IList<ISort> sorts);

        int GetCount(IPredicateGroup predicateGroup);

        #endregion
    }
}
