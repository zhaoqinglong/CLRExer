using System;
using CLRExer.Delegates;
using CLRExer.Generic;
using TokenBusiness.Jwt;
namespace CLRExer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region generic exer
            //new DictionaryGeneric().CreateDictionaryGeneric();
            #endregion

            #region delegate

            //DelegateDemo.Excute();

            #endregion

            #region AttributeDemo

            new AttributeDemo.AttributeDemo().AttributeExcute();

            #endregion

            #region JwtToken

            var token = new Token();
            var jwt = token.GetTokenJwt();
            token.DecryptJwt();
            Console.WriteLine(jwt);

            #endregion

            Console.ReadLine();
        }
    }
}
