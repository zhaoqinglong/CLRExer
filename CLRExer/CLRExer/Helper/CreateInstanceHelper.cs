using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.Helper
{
    /// <summary>
    /// 反射创建实例
    /// </summary>
    public static class CreateInstanceHelper
    {
        public static object CreateInstance(Type t)
        {
            object o = null;
            try
            {
                o = Activator.CreateInstance(t);
                Console.WriteLine("已创建{0}的实例", t.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }

            return o;
        }
    }
}
