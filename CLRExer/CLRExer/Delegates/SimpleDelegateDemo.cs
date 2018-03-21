using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.Delegates
{
    //委托定义
    public delegate void FeedBack(int input);

    public class SimpleDelegateDemo
    {

        public void Excute()
        {
            FeedBack fb = new FeedBack(DoNothing);
            fb(1);
            //fb.Invoke(1);
        }

        /// <summary>
        /// 被调用的方法
        /// </summary>
        /// <param name="input"></param>
        private void DoNothing(int input)
        {
            Console.WriteLine("input is {0};", input);
        }
    }
}
