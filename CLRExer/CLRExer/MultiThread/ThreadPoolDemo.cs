using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLRExer.MultiThread
{
  public static class ThreadPoolDemo
    {
        public static void Excute()
        {
            Console.WriteLine("Main Thread：开始队列进入一个异步线程，线程id：{0}；",Thread.CurrentThread.ManagedThreadId);
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
           
            //使用task完成相同的任务
            new Task(ComputeBoundOp,5).Start();
            Task.Run(() => ComputeBoundOp(5));

            Console.WriteLine("Main Thread：做主线程的其他任务任务；");
            //模拟其他任务
            Thread.Sleep(10000);
            Console.WriteLine("Main Thread End；");
        }

        /// <summary>
        /// 阻止上下文流动
        /// </summary>
        public static void SuppressDataFlow()
        {
            //阻止上下文流动
            ExecutionContext.SuppressFlow();
        }


        private static void ComputeBoundOp(object state)
        {

            Console.WriteLine("In ComputeBoundOp: state={0}，线程id：{1}；",state,Thread.CurrentThread.ManagedThreadId);

            //模拟其他任务
            Thread.Sleep(2000);

            Console.WriteLine("ComputeBoundOp Thread End；");
        }


    }




}
