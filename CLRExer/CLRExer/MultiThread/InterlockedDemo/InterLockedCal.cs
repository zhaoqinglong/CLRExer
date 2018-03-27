using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace CLRExer.MultiThread.InterlockedDemo
{
   public class InterLockedCal
    {
        public void Excute()
        {
            int count = 1;

            //两个相加，并返回相加的结果
            var res1 = Interlocked.Add(ref count, 11);
            Console.WriteLine(" Interlocked.Add res is {0}, count is {1}", res1, count);

            //  //自减，并返回结果
            var res2 = Interlocked.Decrement(ref count);
            Console.WriteLine(" Interlocked.Decrement res is {0}, count is {1}", res2, count);


            //设为指定值，并返回原值
            var res3 = Interlocked.Exchange(ref count,100);
            Console.WriteLine(" Interlocked.Exchange res is {0}, count is {1}", res3, count);

            Timer t=new Timer(x=>{Console.WriteLine("timer");});
            
        }
    }
}
