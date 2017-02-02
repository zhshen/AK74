using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCS.Library.Core.Caching
{
    /// <summary>
    /// Cache队列的虚基类
    /// </summary>
    public abstract class CacheQueueBase
    {
        //private CachingPerformanceCounters totalCounters;
        //private CachingPerformanceCounters counters;
        //private DateTime lastClearTime = SNTPClient.AdjustedUtcTime;
        private DateTime lastClearTime = DateTime.UtcNow;
        protected readonly ReaderWriterLockSlim rWLock = new ReaderWriterLockSlim();

        /// <summary>
        /// Cache项的数量
        /// </summary>
        public abstract int Count
        {
            get;
        }

        /// <summary>
        /// 最后清除时间
        /// </summary>
        public DateTime LastClearTime
        {
            get
            {
                return this.lastClearTime;
            }
            internal set
            {
                this.lastClearTime = value;
            }
        }

        /// <summary>
        /// 清除Cache队列
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// 是否都标记为更新
        /// </summary>
        public abstract void SetChanged();

        /// <summary>
        /// 虚方法，删除Cache项
        /// </summary>
        /// <param name="cacheItem">被删除的Cache项</param>
        internal protected abstract void RemoveItem(CacheItemBase cacheItem);

        /// <summary>
        /// 得到所有项的描述信息
        /// </summary>
        /// <returns></returns>
        public abstract CacheItemInfoCollection GetAllItemsInfo();

        /// <summary>
        /// 重载ToString。输出内部的项数
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = base.ToString();

            result += string.Format("Count={0:#,##0}, LastClearTime={1:yyyy-MM-dd HH:mm:ss.fff}", this.Count, this.LastClearTime);

            return result;
        }

        /// <summary>
        /// 构造方法，初始化性能指针
        /// </summary>
        protected CacheQueueBase()
        {
            this.InitPerformanceCounters(this.GetType().Name);
        }

        /// <summary>
        /// 构造方法，初始化性能指针
        /// </summary>
        protected CacheQueueBase(string instanceName)
        {
            this.InitPerformanceCounters(instanceName);
        }

        protected void DoWriteAction(Action action)
        {
            if (action != null)
            {
                this.rWLock.EnterWriteLock();

                try
                {
                    action();
                }
                finally
                {
                    this.rWLock.ExitWriteLock();
                }
            }
        }

        protected T DoWriteFunc<T>(Func<T> func)
        {
            T result = default(T);

            if (func != null)
            {
                this.rWLock.EnterWriteLock();

                try
                {
                    result = func();
                }
                finally
                {
                    this.rWLock.ExitWriteLock();
                }
            }

            return result;
        }

        protected void DoReadAction(Action action)
        {
            if (action != null)
            {
                this.rWLock.EnterReadLock();

                try
                {
                    action();
                }
                finally
                {
                    this.rWLock.ExitReadLock();
                }
            }
        }

        protected T DoReadFunc<T>(Func<T> func)
        {
            T result = default(T);

            if (func != null)
            {
                this.rWLock.EnterReadLock();

                try
                {
                    result = func();
                }
                finally
                {
                    this.rWLock.ExitReadLock();
                }
            }

            return result;
        }

        /// <summary>
        /// 初始化性能监视指针
        /// </summary>
        /// <param name="instanceName">本地性能监视器的指针</param>
        protected void InitPerformanceCounters(string instanceName)
        {
            //if (this.totalCounters == null)
            //    this.totalCounters = new CachingPerformanceCounters("_Total_");

            //if (this.counters == null)
            //{
            //    instanceName.CheckStringIsNullOrEmpty("instanceName");
            //    this.counters = new CachingPerformanceCounters(instanceName);
            //}
        }

        ///// <summary>
        ///// 所有Cache的性能指针
        ///// </summary>
        //protected CachingPerformanceCounters TotalCounters
        //{
        //    get
        //    {
        //        return this.totalCounters;
        //    }
        //}

        ///// <summary>
        ///// 性能指针
        ///// </summary>
        //protected CachingPerformanceCounters Counters
        //{
        //    get
        //    {
        //        return this.counters;
        //    }
        //}
    }
}
