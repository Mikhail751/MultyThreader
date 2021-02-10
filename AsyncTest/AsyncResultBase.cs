using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTest
{
    class AsyncResultBase
    {
        public int Counter;
        public object[] result;
        public virtual void Work(object args) { }
        public object Run(object[] InputData)
        {
            Counter = InputData.Length;
            result = new object[InputData.Length];
            Thread[] streams = new Thread[result.Length];
            for(int i = 0; i < result.Length; i++)
            {
                streams[i] = new Thread(new ParameterizedThreadStart(Work));
            }
            for(int i = 0; i < result.Length; i++)
            {
                streams[i].Name = i.ToString();
                streams[i].Start(InputData[i]);
            }
            while (Counter != 0) { continue; }
            return MergeData(result);
        }
        public virtual object MergeData(object[] data) { return null; }
    }
}
