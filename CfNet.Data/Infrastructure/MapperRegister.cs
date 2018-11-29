﻿using CfNet.Data.Mapper;


/****************************************************************
*   Author：L
*   Time：2018/11/22 9:30:29
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Data.Infrastructure
{
    public class MapperRegister
    {
        #region Field
        #endregion

        #region Ctor

        public static void Initialize()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(CustomMapper<>);
        }

        #endregion

        #region Method
        #endregion
    }
}
