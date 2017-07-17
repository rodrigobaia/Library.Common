using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RVBConsulting.Library.Common.TestsUnits
{
    [TestClass]
    public class CurrencyWritenExtensiveExtenderTest
    {
        [TestMethod]
        public void ExtensiceNumberTestSucess()
        {
            var valor = 1593.32M;

            var valorExtenso = valor.ExtensiceNumber();

            Assert.IsTrue(true);
        }
    }
}
