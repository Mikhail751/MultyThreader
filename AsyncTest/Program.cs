using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace AsyncTest
{
    class Pair
    {
        public long start, end;
        public Pair(long start, long end)
        {
            this.start = start;
            this.end = end;
        }
    }
    class Program
    {
        public static long PartSum(object p)
        {
            Pair p1 = (Pair)p;
            long start = p1.start;
            long end = p1.end;
            long res = 0;
            for (long i = start; i != end + 1; i++)
            {
                //Console.WriteLine($"Now sum is [{res}] and plusing is [{i}] -> sum is [{res + i}].");
                res += i;
            }
             Console.WriteLine($"Sum of range from [{start}] to [{end}] is [{res}].");
            return res;
        }
        public static long SumOfArray(object[] args)
        {
            long r = 0;
            foreach (var item in args)
            {
                r += (long)item;
            }
            return r;
        }
        public static void Main(string[] args)
        {
            AsyncRes w = new AsyncRes();
            InputData[] data = new InputData[16];
            long m = 100;
            data[0]  = new InputData(1, 1 * m);
            data[1]  = new InputData(1 * m + 1, 2 * m);
            data[2]  = new InputData(2 * m + 1, 3 * m);
            data[3]  = new InputData(3 * m + 1, 4 * m);
            data[4]  = new InputData(4 * m + 1, 5 * m);
            data[5]  = new InputData(5 * m + 1, 6 * m);
            data[6]  = new InputData(6 * m + 1, 7 * m);
            data[7]  = new InputData(7 * m + 1, 8 * m);
            data[8]  = new InputData(8 * m + 1, 9 * m);
            data[9]  = new InputData(9 * m + 1, 10 * m);
            data[10] = new InputData(10 * m + 1, 11 * m);
            data[11] = new InputData(11 * m + 1, 12 * m);
            data[12] = new InputData(12 * m + 1, 13 * m);
            data[13] = new InputData(13 * m + 1, 14 * m);
            data[14] = new InputData(14 * m + 1, 15 * m);
            data[15] = new InputData(15 * m + 1, 16 * m);
            Stopwatch t = new Stopwatch();
            t.Start();
            long FinalSum = (long)w.Run(data); 
            t.Stop();
            Stopwatch nt = new Stopwatch();
            nt.Start();
            long ntsum = PartSum(new Pair(1, 16 * m));
            nt.Stop();
            double t1 = (double)t.ElapsedMilliseconds / 1000;
            double t2 = (double)nt.ElapsedMilliseconds / 1000;
            double perf = t2 / t1;
            Console.WriteLine($"Threaded time is {t1}. NonThreaded time {t2}. It is {perf} faster.");
            Console.ReadKey();
        }
    }
}
