using MCS.Library.Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MCS.Library.Core.Test.Caching
{
    public class CaachingTest
    {
        [Fact]
        public void ScanvageDurationTest()
        {
            CacheManager.DefaultScanvageInterval = TimeSpan.FromMilliseconds(200);

            DateTime time1 = WaitForChange(CacheManager.LastestScanvageUtcTime);
            DateTime time2 = WaitForChange(time1);

            TimeSpan interval = time2 - time1;

            Assert.True(interval.TotalMilliseconds >= 200);
            Assert.True(interval.TotalMilliseconds < 400);
        }

        [Theory]
        [InlineData("Zheng Shen")]
        public void AddItemPortableCacheQueueTest(string value)
        {
            TestPortableCacheQueue.Instance.Add("Author", "Zheng Shen");
            TestPortableCacheQueue.Instance.Add("Tester", "Rong Shen");

            Assert.Equal(value, TestPortableCacheQueue.Instance["Author"]);
        }

        private static DateTime WaitForChange(DateTime originalTime)
        {
            while (CacheManager.LastestScanvageUtcTime == originalTime)
            {
                Task.Delay(10).Wait();
            }

            return CacheManager.LastestScanvageUtcTime;
        }
    }
}
