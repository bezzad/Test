
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
            injector.Singleton(new Person("ss", 1, 2));
            var injectorStringResult1 = injector.Get<Person>();
            injector.Singleton(new Person("ssd", 1, 2));
            var injectorStringResult2 = injector.Get<Person>();
            Assert.AreEqual(injectorStringResult1, injectorStringResult2);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var injector = new Injector();
            injector.Transient( Injector.WriteResult2);
            var injectorIntegerResult1 = injector.Get<Logger>();
            injector.Transient(Injector.WriteResult2);
            var injectorIntegerResult2 = injector.Get<Logger>();
            Assert.AreNotEqual(injectorIntegerResult2, injectorIntegerResult1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreNotEqual(Injector.WriteResult(), Injector.WriteResult() + 2);
        }
        public void TestMethod4()
        {
            Assert.AreNotEqual(Injector.WriteResult2(), Injector.WriteResult2());
        }
    }
}