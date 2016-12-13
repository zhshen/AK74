using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Library.Core.Extensions
{
    /// <summary>
    /// 字符串扩展方法类
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 字符串不是Null且Empty
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string data)
        {
            bool result = false;

            if (data != null)
                result = (string.IsNullOrEmpty(data) == false);

            return result;
        }

        /// <summary>
        /// 如果字符串不为空，则执行Action
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns>返回传入的data</returns>
        public static string IsNotEmpty(this string data, Action<string> action)
        {
            if (data.IsNotEmpty() && action != null)
                action(data);

            return data;
        }

        /// <summary>
        /// 如果字符串不为空，则执行Func
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="data"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static R IsNotEmpty<R>(this string data, Func<string, R> func)
        {
            R result = default(R);

            if (data.IsNotEmpty() && func != null)
                result = func(data);

            return result;
        }

        /// <summary>
        /// 字符串是否为Null或Empty
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string data)
        {
            return string.IsNullOrEmpty(data);
        }

        /// <summary>
        /// 如果字符串为空，则返回替代的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="replacedData"></param>
        /// <returns></returns>
        public static string NullOrEmptyIs(this string data, string replacedData)
        {
            string result = data;

            if (result.IsNullOrEmpty())
                result = replacedData;

            return result;
        }

        /// <summary>
        /// 如果字符串为空，则执行Action
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns>返回传入的data</returns>
        public static string IsNullOrEmpty(this string data, Action action)
        {
            if (string.IsNullOrEmpty(data) && action != null)
                action();

            return data;
        }

        /// <summary>
        /// 字符串是否为Null、Empty和WhiteSpace
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string data)
        {
            return string.IsNullOrWhiteSpace(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns>返回传入的data</returns>
        public static string IsNullOrWhiteSpace(this string data, Action action)
        {
            if (string.IsNullOrWhiteSpace(data) && action != null)
                action();

            return data;
        }

        /// <summary>
        /// 字符串不是Null、Empty和WhiteSpace
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsNotWhiteSpace(this string data)
        {
            bool result = false;

            if (data != null)
                result = (string.IsNullOrWhiteSpace(data) == false);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        public static void IsNotWhiteSpace(this string data, Action<string> action)
        {
            if (data.IsNotWhiteSpace() && action != null)
                action(data);
        }

        /// <summary>
        /// 大小写无关的比较
        /// </summary>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns></returns>
        public static int IgnoreCaseCompare(this string strA, string strB)
        {
            return string.Compare(strA, strB, true);
        }
    }
}
