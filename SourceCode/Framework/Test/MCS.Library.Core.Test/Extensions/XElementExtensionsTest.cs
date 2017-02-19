using MCS.Library.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace MCS.Library.Core.Test.Extensions
{
    public class XElementExtensionsTest
    {
        [Fact]
        public void AttributeValueTest()
        {
            XElement root = PrepareRootXElement();

            Assert.Equal(100, root.Attribute("shelfID", 0));
        }

        [Fact]
        public void AttributeDefaultValueTest()
        {
            XElement root = PrepareRootXElement();

            Assert.Equal(1024, root.Attribute("storeID", 1024));
        }

        private static XElement PrepareRootXElement()
        {
            return XElement.Parse("<Books shelfID='100'><Book id='01'><Name>一地鸡毛</Name></Book></Books>");
        }
    }
}
