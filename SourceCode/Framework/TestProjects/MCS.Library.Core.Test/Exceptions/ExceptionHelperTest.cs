using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MCS.Library.Core.Test.Exceptions
{
    public class ExceptionHelperTest
    {
        [Theory]
        [InlineData("NotNull !")]
        public void NullCheckFalseTest(string value)
        {
            value.NullCheck("value");
        }

        [Theory]
        [InlineData((string)null)]
        public void NullCheckTrue(string value)
        {
            Assert.Throws<ArgumentNullException>(() => value.NullCheck("value"));
        }

        [Theory]
        [InlineData((string)null)]
        public void NullCheckTrueWithCustomExceptionTest(string value)
        {
            CustomException ex = 
                Assert.Throws<CustomException>(() => value.NullCheck((msg) => new CustomException(msg), "The param name is {0}", "value"));

            Assert.Equal("The param name is value", ex.Message);
        }

        [Theory]
        [InlineData("Not Empty !")]
        public void StringEmptyFalseTest(string value)
        {
            value.CheckStringIsNullOrEmpty("value");
        }

        [Theory]
        [InlineData("")]
        public void StringEmptyTrue(string value)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => value.CheckStringIsNullOrEmpty("value"));

            Assert.Equal("字符串参数value不能为Null或空串", ex.Message);
        }

        [Theory]
        [InlineData((string)null)]
        public void StringEmptyTrueWithCustomExceptionTest(string value)
        {
            CustomException ex =
                Assert.Throws<CustomException>(() => value.CheckStringIsNullOrEmpty((msg) => new CustomException(msg), "value"));

            Assert.Equal("value", ex.Message);
        }
    }
}
