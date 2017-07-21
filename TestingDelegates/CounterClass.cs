using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestingDelegates
{
    class CounterClass
    {
        TimerTick tick;

        //Constructor
        public CounterClass(TimerTick tick)
        {
            Thread counter = new Thread(new ThreadStart(CounterThread));
            this.tick = tick;
            counter.Start();
        }

        private void CounterThread()
        {
            int counter = 0;

            while(true)
            {
                Console.WriteLine(counter);
                counter++;
                Thread.Sleep(1000);
                tick(counter);
            }
        }

    }
}
