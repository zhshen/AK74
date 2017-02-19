using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Library.Core.Caching
{
    public class CacheItemInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            get;
            internal set;
        }
    }

    /// <summary>
    /// Cache项信息的集合
    /// </summary>
    public class CacheItemInfoCollection : CollectionBase
    {
        /// <summary>
        /// 增加一项
        /// </summary>
        /// <param name="info"></param>
        internal void Add(CacheItemInfo info)
        {
            List.Add(info);
        }

        /// <summary>
        /// 取得第n项信息
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CacheItemInfo this[int index]
        {
            get
            {
                return (CacheItemInfo)List[index];
            }
        }
    }
}
