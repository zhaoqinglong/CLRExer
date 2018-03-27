using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLRExer.MultiThread
{
    internal sealed class Type1 { }

    internal sealed class Type2 { }

  public static class AsyncDemo
    {
        private static async Task<string> MethodAsync1()
        {
            Task<Type1> r=new Task<Type1>(()=>new Type1());

            Console.WriteLine("this is Type1,threadId is {0}",Thread.CurrentThread.ManagedThreadId);
           
             await r;
           var t= r.Result;
            return "s";
        }

        private static async Task<Type2> MethodAsync2()
        {
            Console.WriteLine("this is Type2,threadId is {0}", Thread.CurrentThread.ManagedThreadId);
            return await new Task<Type2>(() => new Type2());

        }



        private static async Task<string> MyMethodAsync(int input)
        {
            int local = input;
            Console.WriteLine("this is MyMethodAsync,threadId is {0}", Thread.CurrentThread.ManagedThreadId);
            try
            {
                string type1 = await MethodAsync1();
                var len=type1.Length;
                
                Console.WriteLine("this is type1 c,type1 is {0}", type1);
                for (int i = 0; i < 3; i++)
                {
                    Type2 type2 = await MethodAsync2();
                    Console.WriteLine("this is for,threadId is {0}", Thread.CurrentThread.ManagedThreadId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.WriteLine("finally");
            }
            return "done";
        }

        public async  static Task  Excute()
        {
           await MyMethodAsync(10);
        }
    }

}
