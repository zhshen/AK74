using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Library.Core.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// 执行线程同步操作
        /// </summary>
        /// <param name="syncObj"></param>
        /// <param name="action"></param>
        public static void DoSyncAction(this object syncObj, Action action)
        {
            if (syncObj != null && action != null)
            {
                lock (syncObj)
                {
                    action();
                }
            }
        }

        /// <summary>
        /// 执行线程同步函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="syncObj"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T DoSyncFunc<T>(this object syncObj, Func<T> func)
        {
            T result = default(T);

            if (syncObj != null && func != null)
            {
                lock (syncObj)
                {
                    result = func();
                }
            }

            return result;
        }
    }
}
