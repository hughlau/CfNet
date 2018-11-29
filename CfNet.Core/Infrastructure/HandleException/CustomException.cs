

/****************************************************************
*   Author：L
*   Time：2018/11/29 9:33:21
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
using System;
using System.Runtime.Serialization;

namespace CfNet.Core.Infrastructure.HandleException
{
    [Serializable]
    public partial class CustomException: Exception
    {
        #region Field
        #endregion

        #region Ctor

        public CustomException()
        {
        }

        public CustomException(string message)
            : base(message)
        {
        }


        public CustomException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        protected CustomException(SerializationInfo
            info, StreamingContext context)
            : base(info, context)
        {
        }


        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion

        #region Method
        #endregion
    }
}
