
using DISample;

namespace DISampleTest

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var injector = new Injector();
            injector.Singleton("salam");
            var injectorStringResult1 = injector.Get<string>();
            injector.Singleton("salamw");
            var injectorStringResult2 = injector.Get<string>();
            Assert.AreEqual(injectorStringResult1, injectorStringResult2);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var injector = new Injector();
            injector.Transient(Injector.WriteResult);
            var injectorIntegerResult1 = injector.Get<int>();
            injector.Transient(Injector.WriteResult);
            var injectorIntegerResult2 = injector.Get<int>();
            Assert.AreNotEqual(injectorIntegerResult2, injectorIntegerResult1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreNotEqual(Injector.WriteResult(), Injector.WriteResult() + 2);
        }
    }
}