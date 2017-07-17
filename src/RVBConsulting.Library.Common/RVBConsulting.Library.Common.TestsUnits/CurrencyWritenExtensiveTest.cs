using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RVBConsulting.Library.Common.TestsUnits
{
    /// <summary>
    /// Summary description for CurrencyWritenExtensiveTest
    /// </summary>
    [TestClass]
    public class CurrencyWritenExtensiveTest
    {

        /// <summary>
        /// Currencies the writen extensive test success.
        /// </summary>
        [TestMethod]
        public void CurrencyWritenExtensiveTestSuccess()
        {
            var valor = Convert.ToDecimal("50987,32").ExtensiceNumber();

            Assert.AreEqual(valor, "cinqüenta mil novecentos e oitenta e sete reais e trinta e dois centavos");
        }
    }
}
