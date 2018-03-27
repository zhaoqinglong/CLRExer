using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CLRExer.MultiThread.InterlockedDemo
{
   public class MultiWebRequests
    {
        //用于协调所有异步操作
        private AsyncCoordinator m_ac=new AsyncCoordinator();


        private Dictionary<string,object> m_servers=new Dictionary<string, object>()
        {
            { "https://www.mi.com/",null},
            { "https://www.cnblogs.com/",null},
            { "http://192.168.100.1/",null}
        };

        public MultiWebRequests(int timeout = Timeout.Infinite)
        {
            var httpClient = new HttpClient();

            foreach (var server in m_servers.Keys)

            {
                m_ac.AboutToBegin(1);
                httpClient.GetByteArrayAsync(server).ContinueWith(task => ComputeResult(server,task));
            }

            m_ac.AllBegun(AllDone,timeout);
        }

        public void Cancel()
        {
            m_ac.Cancel();
        }

        //完成任务处理
        private void ComputeResult(string server, Task<Byte[]> task)
        {
            object result;
            if (task.Exception != null)
            {
                result = task.Exception.Message;
            }
            else
            {
                //在线程池上处理I/O完成

                result = task.Result.Length;
            }
            //保存结果，指出操作已经完成
            m_servers[server] = result;
            m_ac.JustEnded();

        }

        private void AllDone(CoordinationStatus status)
        {
            switch (status)
            {
                case CoordinationStatus.Cancel:
                    Console.WriteLine("operation canceled");
                    break;
                case CoordinationStatus.Timeout:
                    Console.WriteLine("operation timeout");
                    break;

                case CoordinationStatus.AllDone:
                    Console.WriteLine("operation AllDone");
                    foreach (var server in m_servers)
                    {
                        Console.WriteLine("url is {0},result is {1}",server.Key,server.Value);
                    }
                    break;
            }
        }

       
    }
}
