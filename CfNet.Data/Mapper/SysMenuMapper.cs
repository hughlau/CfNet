using CfNet.Core.Domain;
using DapperExtensions.Mapper;
using System;


/****************************************************************
*   Author：L
*   Time：2018/11/21 15:57:20
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Data.Mapper
{
    [Serializable]
    public class SysMenuMapper:ClassMapper<SysMenu>
    {
        #region Field
        #endregion

        #region Ctor

        public SysMenuMapper()
        {
            base.Table("Sys_Menu");
            AutoMap();
        }

        #endregion

        #region Method

        #endregion
    }
}
