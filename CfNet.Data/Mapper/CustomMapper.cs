﻿using CfNet.Core.Domain;
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

    public class CustomMapper<T>: ClassMapper<T> where T:class
    {
        #region Field
        #endregion

        #region Ctor

        #endregion

        #region Method

        public override void Table(string tableName)
        {
            if (tableName.Equals("SysMenu", StringComparison.CurrentCultureIgnoreCase))
            {
                TableName = "Sys_Menu";
            }
            if (tableName.Equals("SysUser", StringComparison.CurrentCultureIgnoreCase))
            {
                TableName = "Sys_User";
            }
            if (tableName.Equals("SysUserAuth", StringComparison.CurrentCultureIgnoreCase))
            {
                TableName = "Sys_User_Auth";
            }
            if (tableName.Equals("SysPage", StringComparison.CurrentCultureIgnoreCase))
            {
                TableName = "Sys_Page";
            }
            AutoMap();
        }

        #endregion
    }
}
