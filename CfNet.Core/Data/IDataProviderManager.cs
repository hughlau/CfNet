using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/29 9:48:07
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Data
{
    public interface IDataProviderManager
    {
        #region Field
        #endregion

        #region Ctor
        #endregion

        #region Method

        IDataProvider LoadDataProvider();

        #endregion
    }
}
