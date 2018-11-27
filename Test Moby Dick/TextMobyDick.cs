using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moby_Dick;

namespace Test_Moby_Dick
{
    [TestClass]
    public static class TextMobyDick
    {
        [TestMethod]
        public static void TestClearString()
        {
            ClearString clearString = new ClearString();
           
            string sonucClearString = clearString.Method("\r\nege\r\n");

            Assert.AreEqual("ege", sonucClearString);
        }
    }
}
