using System;
using CLRExer.Delegates;
using CLRExer.Generic;

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

            int? a = 0;
            var s = a.GetType();
            
            Console.WriteLine(s.ToString());

            Console.ReadLine();
        }
    }
}
