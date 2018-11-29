using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/29 9:13:08
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Domain.Base
{
    public abstract partial class BaseEntity
    {
        #region Field
        #endregion

        #region Ctor
        #endregion

        #region Method

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }

        #endregion
    }
}
