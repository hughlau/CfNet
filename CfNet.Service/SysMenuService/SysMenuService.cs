using CfNet.Core.Domain;
using CfNet.Data.Infrastructure;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/21 16:54:24
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.SysMenuService
{
    public partial class SysMenuService : ISysMenuService
    {
        #region Field

        private readonly IRepository<SysMenu> _sysmenuRepository;

        #endregion

        #region Ctor

        public SysMenuService(IRepository<SysMenu> sysmenuRepository)
        {
            this._sysmenuRepository = sysmenuRepository;
        }



        #endregion

        #region Method

        public IList<SysMenu> GetAll()
        {
            try
            {
                return _sysmenuRepository.GetModels(null);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
    }
}
