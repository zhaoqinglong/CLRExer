using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLRExer.MultiThread
{
  public  class DownLoadUrlAsync
    {

        public void Excute()
        {
            Console.WriteLine("this is before Excute,threadId is {0}", Thread.CurrentThread.ManagedThreadId);
            var t = GetUrl().ContinueWith(task =>
            {
                Console.WriteLine("this is ContinueWith Excute,threadId is {0},result is {1}",
                    Thread.CurrentThread.ManagedThreadId, task.Result);
            });
            Console.WriteLine("this is Excute,threadId is {0},t IsCompleted is {1}", Thread.CurrentThread.ManagedThreadId,t.IsCompleted);
        }
        private static async Task<int> GetUrl()
        {
            var httpClient = new HttpClient();

            var url = "https://www.cnblogs.com/";
            Console.WriteLine("this is before GetUrl,threadId is {0}", Thread.CurrentThread.ManagedThreadId);
            var res = await httpClient.GetByteArrayAsync(url);
            Console.WriteLine("this is GetUrl,threadId is {0}", Thread.CurrentThread.ManagedThreadId);
            return res.Length;
        }
    }
}
