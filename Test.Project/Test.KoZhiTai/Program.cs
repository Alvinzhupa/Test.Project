using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Test.KoZhiTai
{
    class Program
    {

        //如果这定义的时候,传入True:Auto会自动变成false,并且直接指定WaitOne(指定时间)或者set()进行启动; manual则是传入true,那么一直都是true,传入fasle,那么一直读是fasle,除非指定Reset(),才会进入wait的状态
        static EventWaitHandle _manualResetEvent = new ManualResetEvent(true);

        static void Main(string[] args)
        {

            Thread t1 = new Thread(Thread1Foo);
            t1.Start(); //启动线程1
            Thread.Sleep(1000);
            //_manualResetEvent.Set();
            //Thread t2 = new Thread(Thread2Foo);
            //t2.Start(); //启动线程2
            //Thread.Sleep(1000); //睡眠当前主线程，即调用BT_Temp_Click的线程
            //_manualResetEvent.Set();   //想象成将IsRelease设为True 
            //Thread.Sleep(1000); //睡眠当前主线程，即调用BT_Temp_Click的线程
            //_manualResetEvent.Set();   //想象成将IsRelease设为True 

            Console.Read();
        }

        static void Thread1Foo()
        {
            while (true)
            {
                _manualResetEvent.WaitOne(1000);
                _manualResetEvent.Reset();
                Console.WriteLine("t1 end");
            }
        }

        static void Thread2Foo()
        {
            while (true)
            {
                _manualResetEvent.WaitOne();
                Console.WriteLine("t2 end");
            }
        }
    }

}
