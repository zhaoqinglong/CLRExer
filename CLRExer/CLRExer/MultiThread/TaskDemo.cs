﻿using System;
using System.Collections.Generic;
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
            //创建一个task
            Task<Int64> t1 = new Task<Int64>((x) => Sum((Int64) x),
            input);
            t1.Start();

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
