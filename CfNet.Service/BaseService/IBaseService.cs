using CfNet.Core.Infrastructure;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/27 17:20:41
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.BaseService
{
    public interface IBaseService<T> where T:class,new()
    {

        #region Method

        IList<T> GetAll();

        PageDataView<T> GetPageView(IPredicateGroup predicateGroup, int pageIndex, int pageSize, IList<ISort> sorts);

        int GetCount(IPredicateGroup predicateGroup);

        #endregion
    }
}
