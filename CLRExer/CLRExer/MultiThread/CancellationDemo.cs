using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CLRExer.MultiThread
{
    /// <summary>
    /// 取消线程demo
    /// 协作式取消
    /// 构造一个CancellationTokenSource后，从它的Token属性中获得一个或多个CancellationToken实例，并传给你的操作，使操作可以取消
    /// </summary>
    public class CancellationDemo
    {

        /// <summary>
        /// 构造一个CancellationTokenSource后，从它的Token属性中获得一个或多个CancellationToken实例，并传给你的操作，使操作可以取消
        /// </summary>
        public static void CancellationGo()
        {
            //构造一个CancellationTokenSource
            CancellationTokenSource cts =new CancellationTokenSource();

            //取消后的执行操作
            cts.Token.Register(() => Console.WriteLine("canceled 1"));
            cts.Token.Register(() => Console.WriteLine("canceled 2"));

            //放入线程池开始工作
            ThreadPool.QueueUserWorkItem(x => Count(cts.Token, 100));

            Console.WriteLine("press  to cancel the operation");
            Console.ReadLine();

            cts.Cancel();
          
        }


        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="token"></param>
        /// <param name="countTo"></param>
        private static void Count(CancellationToken token,Int32 countTo)
        {
            for (int i = 0; i < countTo; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("count is cancelled");
                    break;
                }
                Console.WriteLine(i);
                Thread.Sleep(2000);
            }
            Console.WriteLine("count is done");
        }
    }

  
}
