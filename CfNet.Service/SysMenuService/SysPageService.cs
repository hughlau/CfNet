using CfNet.Core.Domain;
using CfNet.Data.Infrastructure;
using CfNet.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/12/26 17:21:01
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.SysMenuService
{
    public partial class SysPageService:BaseService<SysPage>,ISysPageService
    {

        #region =============属性============



        #endregion

        #region ===========构造函数==========

        public SysPageService(IRepository<SysPage> repository) : base(repository)
        {
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============



        #endregion
    }
}
