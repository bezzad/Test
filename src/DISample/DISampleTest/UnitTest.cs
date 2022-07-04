
using DISample;

namespace DISampleTest

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = new Injector();
            x.Singleton("salam");
            var temp1 = x.Get<string>();
            x.Singleton("salamw");
            var temp = x.Get<string>();
            Assert.AreEqual(temp1, temp1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var x = new Injector();
            x.Transient(Injector.WriteResult);
            var temp1 = x.Get<int>();
            x.Transient(Injector.WriteResult);
            var temp = x.Get<int>();
            Assert.AreNotEqual(temp, temp1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreNotEqual(Injector.WriteResult(), Injector.WriteResult() + 2);
        }
    }
}