using TCSSample;
namespace TestTCS
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void Initial()
        {
        }
        [TestMethod]
        public async void TestLargePrimeNumber()
        {
            var res = await MyTaskCompletionSource.GetTaskResult(200);
            Assert.AreEqual(res , "Large Primes number");
        }
        [TestMethod]
        public async void TestNoPrime()
        {
            var res = await MyTaskCompletionSource.GetTaskResult(1);
            Assert.AreEqual(res, "No Prime");
        }
        [TestMethod]
        public async void TestSmallPrimeNumber()
        {
            var res = await MyTaskCompletionSource.GetTaskResult(100);
            Assert.AreEqual(res, "Tiny Primes number");
        }
    }
     
}