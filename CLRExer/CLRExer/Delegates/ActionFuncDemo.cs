using System;
using System.Threading;

namespace CLRExer.Delegates
{
   public class ActionFuncDemo
    {
        /// <summary>
        /// Action demo 
        /// </summary>
        public void ActionExcute()
        {
            long input = 100;

            //Action是无返回值的泛型委托
            Action action= () => { };

            Action<int> ac = x => Console.WriteLine("this is {0}", x);

            Action<long, string> ac1 = (x, y) => Console.WriteLine("this is {0},this is {1}", x, y);

            Action<int, int, int> action2= InputDemo;
            action2(1, 2, 3);
        }

        /// <summary>
        /// Action调用的方法
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="input3"></param>
        private void InputDemo(int input1, int input2, int input3)
        {
            Console.WriteLine("this is input1:{0},this is input2:{1},this is input3:{2}", input1, input2, input3);
        }

        /// <summary>
        /// Func Demo
        /// </summary>
        public void FuncDemo()
        {

            int output = 100;
            // Func是有返回值的泛型委托
           

            //表示没有输入参数，有一个返回参数
            Func<long> func1 = () => { return 1; };


            //表示一个输入参数n，一个返回值sum
            Func<long, long> func2 = n =>
            {
                Int64 sum = 0;
                for (; n > 0; n--)
                {
                    checked
                    {
                        sum += n;
                    }
                }
                Console.WriteLine("计算线程Id：{0}", Thread.CurrentThread.ManagedThreadId);
                return sum;
            };

        }
    }
}
