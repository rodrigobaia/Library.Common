using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RVBConsulting.Library.Common.TestsUnits
{
    /// <summary>
    /// Encryption test class
    /// </summary>
    [TestClass]
    public class CryptigraphyTest
    {

        /// <summary>
        /// Encrypts the test success.
        /// </summary>
        [TestMethod]
        public void EncryptTestSuccess()
        {
            var valor = "RVBConsulting.Library.Common".Encrypt();

            Assert.AreEqual(valor, "hU/JWyZnZn1aIgyUWoBtu/NsqU8Dlb3MmZR0E37QfiY=");
        }
        
        /// <summary>
        /// Decrypts the test sucess.
        /// </summary>
        [TestMethod]
        public void DecryptTestSucess()
        {
            var valor = "hU/JWyZnZn1aIgyUWoBtu/NsqU8Dlb3MmZR0E37QfiY=".Decrypt();

            Assert.AreEqual(valor, "RVBConsulting.Library.Common");

        }

        /// <summary>
        /// Encrypts the hash test success.
        /// </summary>
        [TestMethod]
        public void EncryptHashTestSuccess()
        {
            var valor = "RVBConsulting.Library.Common".EncryptHash();

            Assert.AreEqual(valor, "a8f144fd8b498d07f0891948dc7cc147");
        }
    }
}
