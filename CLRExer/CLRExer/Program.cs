using System;
using System.Threading.Tasks;
using CLRExer.Delegates;
using CLRExer.Generic;
using CLRExer.MultiThread;
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
            #endregion

            Console.ReadLine();
        }
    }
}
