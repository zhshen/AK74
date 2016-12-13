using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MCS.Library.Core.Extensions;

namespace MCS.Library.Core.Test
{
    public class StringExtenstionsTest
    {
        public StringExtenstionsTest()
        {
        }

        [Theory]
        [InlineData("Hello World !")]
        public void IsNotEmptyTest(string value)
        {
            Assert.True(value.IsNotEmpty());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsNullOrEmptyTest(string value)
        {
            Assert.True(value.IsNullOrEmpty());
        }

        [Theory]
        [InlineData("Hello World !")]
        public void IsNotWiteSpaceTest(string value)
        {
            Assert.True(value.IsNotWhiteSpace());
        }
    }
}
