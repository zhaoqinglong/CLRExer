using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.Delegates
{

    /// <summary>
    /// 
    /// </summary>
    public sealed class LambdaDemo
    {
        //没有传入参数，只有输出参数的委托
        public Func<string> f = () => "Jeff";

        //一个传入参数，只有输出参数的委托
        public Func<int, string> f2 = (int n) => n.ToString();

        public Func<int, int, string> f3 = (int n1, int n2) => (n1 + n2).ToString();

        public Func<int, int, string> f4 = (int n1, int n2) =>
        {
            var sum = n1 + n2;
            return sum.ToString();
        };


        //定义委托
        delegate void Bar(out int z);

        //如果委托有ref/out参数，必须显示指定 ref/out和类型
        private Bar b = (out int n) => n = 5;
    }
}
