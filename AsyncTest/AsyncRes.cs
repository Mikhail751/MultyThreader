using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTest
{
    class InputData
    {
        public long start, end;
        public InputData(long start, long end)
        {
            this.start = start;
            this.end = end;
        }
    }
    class AsyncRes : AsyncResultBase
    {
        public void Work(object args)
        {
            InputData id = (InputData)args;
            long start = id.start;
            long end = id.end;
            long res = 0;
            for (long i = start; i != end + 1; i++)
            {
                //Console.WriteLine($"Now sum is [{res}] and plusing is [{i}] -> sum is [{res + i}].");
                res += i;
            }
            Console.WriteLine($"Sum of range from [{start}] to [{end}] is [{res}].");
            this.Counter -= 1;
            result[Int64.Parse(Thread.CurrentThread.Name)] = res;
        }
    }
}
