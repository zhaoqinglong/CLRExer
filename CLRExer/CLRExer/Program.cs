using System;
using CLRExer.Generic;

namespace CLRExer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region generic exer
            new DictionaryGeneric().CreateDictionaryGeneric();
            #endregion

            Console.ReadLine();
        }
    }
}
