using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Library.Core.Test.Exceptions
{
    public class CustomException : Exception
    {
        /// <summary>
        /// CustomException
        /// </summary>
        /// <remarks>CustomException的缺省构造函数.
        /// </remarks>
        public CustomException()
        {
        }

        /// <summary>
        /// CustomException的带错误消息参数的构造函数
        /// </summary>
        /// <param name="strMessage">错误消息串</param>
        /// <remarks>CustomException的带错误消息参数的构造函数,该错误消息将在消息抛出异常时显示出来。
        /// <seealso cref="MCS.Library.Expression.ExpTreeExecutor"/>
        /// </remarks>
        public CustomException(string strMessage)
            : base(strMessage)
        {
        }

        /// <summary>
        /// SystemSupportException的构造函数。
        /// </summary>
        /// <param name="strMessage">错误消息串</param>
        /// <param name="ex">导致该异常的异常</param>
        /// <remarks>该构造函数把导致该异常的异常记录了下来。
        /// </remarks>
        public CustomException(string strMessage, Exception ex)
            : base(strMessage, ex)
        {
        }
    }
}
