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

            DelegateDemo.Excute();

            #endregion

            Console.ReadLine();
        }
    }
}
