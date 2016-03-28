using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortableMD5;

namespace PortableMD5Test {
    [TestClass]
    public class HashTest {
        [TestMethod]
        public void TestHashPharse() {

            var phrase1 = "The quick brown fox jumps over the lazy dog";
            var hashedPhrase1 = "9e107d9d372bb6826bd81d3542a419d6";

            var phrase2 = "The quick brown fox jumps over the lazy dog.";
            var hashedPhrase2 = "e4d909c290d0fb1ca068ffaddf22cbd0";

            var h = new MD5();

            var phrase1Processed = h.Process(phrase1);
            Assert.AreEqual(hashedPhrase1, phrase1Processed);

            var phrase2Processed = h.Process(phrase2);
            Assert.AreEqual(hashedPhrase2, phrase2Processed);

            Assert.AreNotEqual(phrase1Processed, phrase2Processed);

        }
    }
}
