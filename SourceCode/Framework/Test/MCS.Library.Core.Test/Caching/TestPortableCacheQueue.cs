using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Library.Core.Caching;

namespace MCS.Library.Core.Test.Caching
{
    public class TestPortableCacheQueue : PortableCacheQueue<string, string>
    {
        public static readonly TestPortableCacheQueue Instance = (TestPortableCacheQueue)CacheManager.GetInstance(typeof(TestPortableCacheQueue));
    }
}
