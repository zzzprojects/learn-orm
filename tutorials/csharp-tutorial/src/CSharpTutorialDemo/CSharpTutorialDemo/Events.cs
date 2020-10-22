using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class Events
    {
        class Counter
        {
            private int total;

            public void Add(int x)
            {
                total += x;

                Console.WriteLine("Count: "+ total);
                if (total == 7)
                {
                    Console.WriteLine("Event raised...");
                    OnThresholdReached(EventArgs.Empty);
                }
            }

            protected virtual void OnThresholdReached(EventArgs e)
            {
                EventHandler handler = ThresholdReached;
                if (handler != null)
                {
                    handler(this, e);
                }
            }

            public event EventHandler ThresholdReached;
        }

        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("Event received.");
        }

        public static void Example1()
        {
            Counter c = new Counter();
            c.ThresholdReached += c_ThresholdReached;

            for (int i = 0; i < 10; i++)
            {
                c.Add(1);
            }
        }
    }
}
