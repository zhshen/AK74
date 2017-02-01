using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Library.Core
{
    /// <summary>
    /// Exception工具，提供了TrueThrow和FalseThrow等方法
    /// </summary>
    /// <remarks>Exception工具，TrueThrow方法判断它的布尔参数值是否为true，若是则抛出异常；FalseThrow方法判断它的布尔参数值是否为false，若是则抛出异常。
    /// </remarks>
    public static class ExceptionHelper
    {
        /// <summary>
        /// 检查对象是否为空，如果为空，抛出ArgumentNullException
        /// </summary>
        /// <param name="data">被检查的对象</param>
        /// <param name="message">参数的名称</param>
        /// <returns>返回传入的data，可以继续进行后续操作</returns>
        [DebuggerNonUserCode]
        public static object NullCheck(this object data, string message)
        {
            return NullCheck<ArgumentNullException>(data, (msg) => new ArgumentNullException(msg), message);
        }

        /// <summary>
        /// 检查对象是否为空，如果为空，抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="buildExFunc"></param>
        /// <param name="message"></param>
        /// <param name="messageParams"></param>
        /// <returns>返回传入的data，可以继续进行后续操作</returns>
        [DebuggerNonUserCode]
        public static object NullCheck<T>(this object data, Func<string, T> buildExFunc, string message = null, params object[] messageParams) where T : System.Exception
        {
            (data == null).TrueThrow<T>(buildExFunc, message, messageParams);

            return data;
        }

        /// <summary>
        /// 如果条件表达式boolExpression的结果值为真(true)，则抛出message指定的错误信息
        /// </summary>
        /// <param name="parseExpressionResult">条件表达式</param>
        /// <param name="message">错误信息</param>
        /// <param name="messageParams">错误信息的参数</param>
        /// <returns>返回传入的parseExpressionResult</returns>
        /// <remarks>
        /// 如果条件表达式boolExpression的结果值为真(true)，则抛出message指定的错误信息
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region = "TrueThrowTest" lang="cs" title="通过判断条件表达式boolExpression的结果值而判断是否抛出指定的异常信息" />
        /// <seealso cref="FalseThrow"/>
        /// <seealso cref="MCS.Library.Logging.LogEntity"/>
        /// </remarks>
        [DebuggerNonUserCode]
        public static bool TrueThrow(this bool parseExpressionResult, string message, params object[] messageParams)
        {
            return TrueThrow(parseExpressionResult, (msg) => new SystemSupportException(msg), message, messageParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parseExpressionResult"></param>
        /// <param name="buildExFunc"></param>
        /// <param name="message"></param>
        /// <param name="messageParams"></param>
        /// <returns></returns>
        public static bool TrueThrow<T>(this bool parseExpressionResult, Func<string, T> buildExFunc, string message = null, params object[] messageParams) where T : System.Exception
        {
            if (parseExpressionResult)
            {
                if (buildExFunc == null)
                    throw new ArgumentNullException("buildExFunc");

                string formattedMessage = message;

                if (message != null)
                    formattedMessage = string.Format(message, messageParams);

                T exception = buildExFunc(formattedMessage);

                throw exception;
            }

            return parseExpressionResult;
        }

        /// <summary>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出strMessage指定的错误信息
        /// </summary>
        /// <param name="parseExpressionResult">条件表达式</param>
        /// <param name="message">错误信息</param>
        /// <param name="messageParams">错误信息参数</param>
        /// <returns>返回传入的parseExpressionResult</returns>
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region = "FalseThrowTest" lang="cs" title="通过判断条件表达式boolExpression的结果值而判断是否抛出指定的异常信息" />
        /// <seealso cref="TrueThrow"/>
        /// <seealso cref="MCS.Library.Logging.LoggerFactory"/>
        /// <remarks>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出message指定的错误信息
        /// </remarks>
        /// <example>
        /// <code>
        /// ExceptionTools.FalseThrow(name != string.Empty, "对不起，名字不能为空！");
        /// </code>
        /// </example>
        [DebuggerNonUserCode]
        public static bool FalseThrow(this bool parseExpressionResult, string message, params object[] messageParams)
        {
            TrueThrow(false == parseExpressionResult, message, messageParams);

            return parseExpressionResult;
        }

        /// <summary>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出message指定的错误信息
        /// </summary>
        /// <typeparam name="T">异常的类型</typeparam>
        /// <param name="parseExpressionResult">条件表达式</param>
        /// <param name="buildExFunc"></param>
        /// <param name="message">错误信息</param>
        /// <param name="messageParams">错误信息参数</param>
        /// <returns>返回传入的parseExpressionResult</returns>
        /// <remarks>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出strMessage指定的错误信息
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region="FalseThrowTest" lang="cs" title="通过判断条件表达式boolExpression的结果值而判断是否抛出指定的异常信息" />
        /// <seealso cref="TrueThrow"/>
        /// <seealso cref="MCS.Library.Core.EnumItemDescriptionAttribute"/>
        /// </remarks>
        /// <example>
        /// <code>
        /// ExceptionTools.FalseThrow(name != string.Empty, typeof(ApplicationException), "对不起，名字不能为空！");
        /// </code>
        /// </example>
        [DebuggerNonUserCode]
        public static bool FalseThrow<T>(this bool parseExpressionResult, Func<string, T> buildExFunc, string message = null, params object[] messageParams) where T : System.Exception
        {
            TrueThrow<T>(false == parseExpressionResult, buildExFunc, message, messageParams);

            return parseExpressionResult;
        }

        /// <summary>
        /// 检查字符串参数是否为Null或空串，如果是，则抛出异常
        /// </summary>
        /// <param name="data">字符串参数值</param>
        /// <param name="paramName">字符串名称</param>
        /// <returns>返回传入的data</returns>
        /// <remarks>
        /// 若字符串参数为Null或空串，抛出ArgumentException异常
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region="CheckStringIsNullOrEmpty" lang="cs" title="检查字符串参数是否为Null或空串，若是，则抛出异常" />
        /// </remarks>
        [DebuggerNonUserCode]
        public static string CheckStringIsNullOrEmpty(this string data, string paramName)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException(string.Format(Resource.StringParamCanNotBeNullOrEmpty, paramName));

            return data;
        }

        /// <summary>
        /// 检查字符串参数是否为Null或空串，如果是，则抛出异常
        /// </summary>
        /// <typeparam name="T">异常的类型</typeparam>
        /// <param name="data">检查字符串参数是否为Null或空串，如果是，则抛出异常</param>
        /// <param name="buildExFunc"></param>
        /// <param name="message"></param>
        /// <returns>返回传入的data</returns>
        [DebuggerNonUserCode]
        public static string CheckStringIsNullOrEmpty<T>(this string data, Func<string, T> buildExFunc, string message = null) where T : System.Exception
        {
            (string.IsNullOrEmpty(data)).TrueThrow(buildExFunc, message);

            return data;
        }

        /// <summary>
        /// 执行一个不抛出异常的操作
        /// </summary>
        /// <param name="action"></param>
        public static void DoSilentAction(Action action)
        {
            if (action != null)
            {
                try
                {
                    action();
                }
                catch (System.Exception)
                {
                }
            }
        }

        /// <summary>
        /// 执行一个不抛出异常的函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T DoSilentFunc<T>(Func<T> func, T defaultValue)
        {
            T result = defaultValue;

            if (func != null)
            {
                try
                {
                    result = func();
                }
                catch (System.Exception)
                {
                }
            }

            return result;
        }
    }
}
