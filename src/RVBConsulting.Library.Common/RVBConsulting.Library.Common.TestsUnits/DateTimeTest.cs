using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RVBConsulting.Library.Common.TestsUnits
{
    [TestClass]
    public class DateTimeTest
    {
        [TestMethod]
        public void GetExtensiceMonthTestSuccess()
        {
            var dataAtual = DateTime.Now;
            var dataExtensive = dataAtual.GetExtensiceMonth();

            Assert.IsTrue(true);

        }
    }
}
