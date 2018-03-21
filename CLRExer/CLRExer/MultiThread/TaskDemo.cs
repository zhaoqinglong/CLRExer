using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLRExer.MultiThread
{
    /// <summary>
    /// Task
    /// </summary>
   public class TaskDemo
    {
        public void Excute()
        {
            long input = 10000000;
            //创建一个有返回值的task
            Task<Int64> t1 = new Task<Int64>((x) => Sum((Int64) x),
            input);
            t1.Start();
            //t1.Status
            //此时，不用等待t1的结果完成，t1完成后，自动会执行此task
            t1.ContinueWith(task => { Console.WriteLine("task1 result is {0},this is continueWith;", task.Result); });

            //显示等待任务执行完毕
            //t1.Wait();
            Console.WriteLine("task1 result is {0},主线程Id：{1}", t1.Result,Thread.CurrentThread.ManagedThreadId);


            //演示可以取消的任务
            CancellationTokenSource cst=new CancellationTokenSource();           
            //创建一个task
            Task<Int64> t2 = new Task<Int64>(()=> Sum(cst.Token,input));
            t2.Start();
            Thread.Sleep(1000);
            cst.Cancel();
            Console.WriteLine("task2 result is {0}", t2.Result);
          
        }

        /// <summary>
        /// Task run demo
        /// </summary>
        public void TaskRunExcute()
        {
            long input = 100;

            //Action是无返回值的泛型委托
            Action<long> ac= x => Console.WriteLine("this is {0}",x) ;

            Action<long,long> ac1 = (x,y)=> Console.WriteLine("this is {0},this is {1}", x,y);

            // Func是有返回值的泛型委托
            long output = 100;
            Func<long> func = () => output;

            Func<long, long> func1 = n =>
            {
                Int64 sum = 0;
                for (; n > 0; n--)
                {
                    checked
                    {
                        sum += n;
                    }
                }
                Console.WriteLine("计算线程Id：{0}", Thread.CurrentThread.ManagedThreadId);
                return sum;
            };

            
            //创建一个无返回值的Task
            Action<object> action = x => { Console.WriteLine("this is Action<int> ,input is  {0}", x); };
            
            Task t = new Task(action, (object)input);

            t.Start();



            //返回值为Task
            Func<Task> funcTask = () => { return new Task(() => Console.WriteLine("0")); };

            Task<long> t1=Task.Run(func);
        }

        private static Int64 Sum(Int64 n)
        {
            Int64 sum = 0;
            for (;n>0; n--)
            {
                checked
                {
                    sum += n;
                }
            }
            Console.WriteLine("计算线程Id：{0}",Thread.CurrentThread.ManagedThreadId);
            return sum;
        }

        //创建可取消的任务
        private static Int64 Sum(CancellationToken ct, Int64 n)
        {
            Int64 sum = 0;
            for (; n > 0; n--)
            {
                //    ct.ThrowIfCancellationRequested();
                if (!ct.IsCancellationRequested)
                {
                    checked
                    {
                        sum += n;
                    }
                    Thread.Sleep(10);
                }             
            }
            return sum;
        }
    }
}
