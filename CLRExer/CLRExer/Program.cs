using System;
using System.Threading.Tasks;
using CLRExer.Delegates;
using CLRExer.Events;
using CLRExer.Generic;
using CLRExer.MultiThread;
using CLRExer.MultiThread.InterlockedDemo;
using CLRExer.Serialization;
using TokenBusiness.Jwt;
namespace CLRExer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            #region generic exer
            //new DictionaryGeneric().CreateDictionaryGeneric();
            #endregion

            #region delegate

            //DelegateDemo.Excute();
            new SimpleDelegateDemo().Excute();
            #endregion

            #region AttributeDemo

            //new AttributeDemo.AttributeDemo().AttributeExcute();

            #endregion

            #region JwtToken

            //var token = new Token();
            //var jwt = token.GetTokenJwt();
            //token.DecryptJwt();
            //Console.WriteLine(jwt);

            #endregion

            #region 多线程
            //执行线程池中的多线程
            //ThreadPoolDemo.Excute();

            //CancellationDemo.CancellationGo();
            //TaskScheduler
            //new  TaskDemo().Excute();
            //AsyncDemo.Excute();


            //new InterLockedCal().Excute();

            //new MultiWebRequests();

            //new DownLoadUrlAsync().Excute();
            #endregion


            #region serialization

            //new SerDemo().SerExcute();

            #endregion

            #region Event
          

            var mail=new MailManager();
           
            //订阅事件
            var fax=new Fax(mail);
            fax.Unregister(mail);
            var mobile=new Mobile(mail);
            //引发事件
            mail.SimulateNewMail("a", "b", "c");

            #endregion


            Console.ReadLine();
        }
    }
}
