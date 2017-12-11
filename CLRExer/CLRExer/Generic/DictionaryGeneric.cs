using System;
using System.Collections.Generic;
using System.Text;
using CLRExer.Helper;

namespace CLRExer.Generic
{
   public class DictionaryGeneric
    {
        public void CreateDictionaryGeneric()
        {
            object o = null;

            //Dictionary<,>
            Type t = typeof(Dictionary<,>);
            o = CreateInstanceHelper.CreateInstance(t);


            //List<>
            t = typeof(List<>);
            o = CreateInstanceHelper.CreateInstance(t);

            //List<int>
            t = typeof(List<int>);
            o = CreateInstanceHelper.CreateInstance(t);

            Console.WriteLine("对象类型："+o.GetType());
        }
    }
}
