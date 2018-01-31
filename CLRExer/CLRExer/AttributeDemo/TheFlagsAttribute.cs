using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.AttributeDemo
{

    [AttributeUsage(AttributeTargets.Enum,Inherited = false)]
    public class TheFlagsAttribute : System.Attribute
    {
        public TheFlagsAttribute()
        {

        }
    }
}
