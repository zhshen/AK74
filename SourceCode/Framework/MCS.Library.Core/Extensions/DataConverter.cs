﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace MCS.Library.Core.Extensions
{
    /// <summary>
    /// 提供字符串与枚举类型的转换，TimeSpan与整形的转换。
    /// </summary>
    /// <remarks>提供字符串和枚举、TimeSpan的转换
    /// </remarks>
    public static class DataConverter
    {
        /// <summary>
        /// 类型转换，提供字符串与枚举型、TimeSpan与整型之间的转换
        /// </summary>
        /// <typeparam name="TSource">源数据的类型</typeparam>
        /// <typeparam name="TResult">目标数据的类型</typeparam>
        /// <param name="srcValue">源数据的值</param>
        /// <returns>类型转换结果</returns>
        /// <remarks>
        /// 数据转换，主要调用系统Convert类的ChangeType方法，但是对于字符串与枚举，整型与TimeSpan类型之间的转换，进行了特殊处理。
        /// <seealso cref="MCS.Library.Core.XmlHelper"/>
        /// </remarks>
        public static TResult ChangeType<TSource, TResult>(TSource srcValue)
        {
            return (TResult)ChangeType(srcValue, typeof(TResult));
        }

        /// <summary>
        /// 字符串与枚举型、TimeSpan与整型之间转换的方法。
        /// </summary>
        /// <typeparam name="TSource">源数据类型</typeparam>
        /// <param name="srcValue">源数据的值</param>
        /// <param name="targetType">目标数据类型</param>
        /// <returns>类型转换后的结果</returns>
        /// <remarks>字符串与枚举型、TimeSpan与整型之间转换的方法。
        /// <seealso cref="MCS.Library.Core.XmlHelper"/>
        /// </remarks>
        public static object ChangeType<TSource>(TSource srcValue, System.Type targetType)
        {
            System.Type srcType = typeof(TSource);

            return ChangeType(srcType, srcValue, targetType);
        }

        /// <summary>
        /// 字符串与枚举型、TimeSpan与整型之间转换的方法。
        /// </summary>
        /// <param name="srcType">源数据类型</param>
        /// <param name="srcValue">源数据的值</param>
        /// <param name="targetType">目标数据类型</param>
        /// <returns>类型转换后的结果</returns>
        /// <remarks>字符串与枚举型、TimeSpan与整型之间转换的方法。
        /// <seealso cref="MCS.Library.Core.XmlHelper"/>
        /// </remarks>
        public static object ChangeType(System.Type srcType, object srcValue, System.Type targetType)
        {
            targetType.NullCheck("targetType");

            bool dealed = false;
            object result = null;

            if (srcType == typeof(object))
                if (srcValue != null)
                    srcType = srcValue.GetType();

            if (srcType == targetType)
            {
                result = srcValue;
                dealed = true;
            }
            else
            {
                if (targetType == typeof(object))
                {
                    result = srcValue;
                    dealed = true;
                }
                else
                {
                    if (targetType.GetTypeInfo().IsEnum)
                    {
                        if (srcType == typeof(string) || srcType == typeof(int) || srcType == typeof(long))
                        {
                            if (srcValue is string && (srcValue).ToString().IsNullOrEmpty())
                            {
                                result = Enum.Parse(targetType, "0");
                            }
                            else
                            {
                                result = Enum.Parse(targetType, srcValue.ToString());
                            }

                            dealed = true;
                        }
                    }
                    else
                    {
                        if (targetType == typeof(string) && srcType == typeof(DateTime))
                        {
                            result = string.Format("{0:yyyy-MM-ddTHH:mm:ss.fff}", srcValue);

                            dealed = true;
                        }
                        else
                        {
                            if (targetType == typeof(TimeSpan))
                            {
                                if (srcType == typeof(TimeSpan))
                                    result = srcValue;
                                else
                                    result = TimeSpan.FromSeconds((double)Convert.ChangeType(srcValue, typeof(double)));

                                dealed = true;
                            }
                            else
                            {
                                if (targetType == typeof(bool) && srcType == typeof(string))
                                    result = StringToBool(srcValue.ToString(), out dealed);
                                else
                                {
                                    if (targetType == typeof(DateTime))
                                    {
                                        if (srcType == typeof(string))
                                        {
                                            if (srcValue == null || srcValue.ToString() == string.Empty)
                                            {
                                                result = DateTime.MinValue;
                                                dealed = true;
                                            }
                                        }
                                        else
                                        {
                                            if (typeof(IDictionary<string, object>).GetTypeInfo().IsAssignableFrom(srcType))
                                            {
                                                result = ((IDictionary<string, object>)srcValue).ToDateTime();
                                                dealed = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((typeof(IDictionary<string, object>).GetTypeInfo().IsAssignableFrom(targetType)) && srcType == typeof(DateTime))
                                        {
                                            result = ((DateTime)srcValue).ToDictionary();
                                            dealed = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (dealed == false)
            {
                if (targetType != typeof(object) && targetType.GetTypeInfo().IsAssignableFrom(srcType))
                {
                    result = srcValue;
                }
                else if (targetType == typeof(DateTime))
                {
                    result = Convert.ToDateTime(srcValue);
                }
                else
                {
                    result = Convert.ChangeType(srcValue, targetType);
                }
            }

            return result;
        }

        /// <summary>
        /// 转换成Javascript的日期对应的整数（从1970年1月1日开始的毫秒数）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToJavascriptDateNumber(this DateTime dt)
        {
            DateTime baseTime = new DateTime(1970, 1, 1, 0, 0, 0, dt.Kind);

            return Convert.ToInt64((dt - baseTime).TotalMilliseconds);
        }

        /// <summary>
        /// Javascript的日期对应的整数（从1970年1月1日开始的毫秒数）转换成DateTime
        /// </summary>
        /// <param name="jsMilliseconds"></param>
        /// <returns></returns>
        public static DateTime JavascriptDateNumberToDateTime(this long jsMilliseconds)
        {
            DateTime baseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return baseTime.AddMilliseconds(jsMilliseconds).ToLocalTime();
        }

        /// <summary>
        /// 将日期类型转换为一个Dictionary，里面包含Ticks和DateKind，主要是和Json序列化中的类型转换相关
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this DateTime dt)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            dict["DateValue"] = dt.Ticks;
            dict["DateKind"] = dt.Kind;

            return dict;
        }

        /// <summary>
        /// 将一个Dictionary转换成DateTime，需要这个Dictionaty中有DateValue值(Ticks)和DateKind值(DateTimeKind)。
        /// 如果没有，则返回DateTime.MinValue
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this IDictionary<string, object> dictionary)
        {
            DateTime result = DateTime.MinValue;

            long ticks = dictionary.GetValue("DateValue", -1L);
            DateTimeKind kind = dictionary.GetValue("DateKind", DateTimeKind.Local);

            if (ticks != -1)
            {
                result = new DateTime(ticks, kind);

                if (result != DateTime.MinValue && result.Kind == DateTimeKind.Utc)
                    result = result.ToLocalTime();
            }

            return result;
        }

        private static bool StringToBool(string srcValue, out bool dealed)
        {
            bool result = false;
            dealed = false;

            srcValue = srcValue.Trim();

            if (srcValue.Length > 0)
            {
                if (srcValue.Length == 1)
                {
                    result = ((string.Compare(srcValue, "0") != 0) && (string.Compare(srcValue, "n", true) != 0));

                    dealed = true;
                }
                else
                {
                    if (string.Compare(srcValue, "YES", true) == 0 || string.Compare(srcValue, "是", true) == 0 || string.Compare(srcValue, "TRUE", true) == 0)
                    {
                        result = true;
                        dealed = true;
                    }
                    else
                    {
                        if (string.Compare(srcValue, "NO", true) == 0 || string.Compare(srcValue, "否", true) == 0 || string.Compare(srcValue, "FALSE", true) == 0)
                        {
                            result = false;
                            dealed = true;
                        }
                    }
                }
            }
            else
            {
                dealed = true;	//空串表示False
            }

            return result;
        }
    }
}
