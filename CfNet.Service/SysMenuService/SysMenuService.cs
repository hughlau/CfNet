﻿using CfNet.Core.Domain;
using CfNet.Data.Infrastructure;
using CfNet.Service.BaseService;
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
    public partial class SysMenuService : BaseService<SysMenu>, ISysMenuService
    {
        #region Field


        #endregion

        #region Ctor

        public SysMenuService(IRepository<SysMenu> repository) : base(repository)
        {
        }



        #endregion

        #region Method


        #endregion

    }
}
