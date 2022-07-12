using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSSample
{
    public class MyTaskCompletionSource
    {
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        private static int CountPrimes(int inputInt)
        {
            int count = 0;
            for (int i = 1; i < inputInt; i++)
                if (IsPrime(i)) 
                    count++;
            
            return count;
        }
        public async static Task<string> GetTaskResult(int inputInt)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>(inputInt);
            var res = CountPrimes(inputInt);
            await Task.Delay(100);
            if (res == 0)
                tcs.SetResult("No Prime");
            else if (res <= 30)
                tcs.SetResult("Tiny Primes number");
            else if (res > 30)
                tcs.SetResult("Large Primes number");
            return tcs.Task.Result;
        }
    }
}
