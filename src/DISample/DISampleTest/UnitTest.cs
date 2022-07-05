
using DISample;

namespace DISampleTest

{
    [TestClass]
    public class UnitTest1
    {
        Injector injector;

        [TestInitialize]
        public void Initial()
        {
            // init per test
            injector = new Injector();
        }

        [TestMethod]
        public void TestInjectPersonType()
        {
            var person = new Person("ss", 1, 2);
            injector.Singleton(person);
            var getPerson = injector.Get<Person>();

            Assert.AreEqual(person, getPerson);
        }

        [TestMethod]
        public void TestInjectLoggerType()
        {
            var person = new Logger(1, "ss");
            injector.Singleton(person);
            var getPerson = injector.Get<Logger>();

            Assert.AreEqual(person, getPerson);
        }

        [TestMethod]
        public void TestUninjectedPersonType()
        {
            //var person = new Person("ss", 1, 2);
            //injector.Singleton(person);
            var getPerson = injector.Get<Person>();
            Assert.AreEqual(null, getPerson);
        }

        [TestMethod]
        public void TestTransiotionInjection()
        {
            var getPersonMethod = ()=> new Person("ss", 1, 2);
            var value = getPersonMethod();
            injector.Transient(getPersonMethod);
            var givenPerson = injector.Get<Person>();
            Assert.AreEqual(value.Name, givenPerson.Name);
        }

    }
}