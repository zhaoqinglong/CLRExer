using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//声明一个委托方法，他的实例引用一个方法
//该方法获取一个int32参数，返回void
internal delegate void Feedback(Int32 value);

namespace CLRExer.Delegates
{
   public sealed class DelegateDemo
    {
        //执行方法
        public static void Excute()
        {
            StaticDelegateDemo();
            InstanceDelegateDemo();
            ChainDelegateDemo1();
            ChainDelegateDemo2();
        }

        /// <summary>
        /// 委托调用静态方法
        /// </summary>
        private static void StaticDelegateDemo()
        {
            Console.WriteLine("----- static delegate demo -----");
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(FeedbackToConsole));
            Counter(1, 3, new Feedback(FeedbackToMsgBox));
            Console.WriteLine("----- end static delegate demo -----");
            Console.WriteLine();
        }


        /// <summary>
        /// 委托调用实例方法
        /// </summary>
        private static void InstanceDelegateDemo()
        {
            Console.WriteLine("----- Instance delegate demo -----");
            DelegateDemo p = new DelegateDemo();
            Counter(1, 3, new Feedback(p.FeedbackToFile));
         
            Console.WriteLine("----- end Instance delegate demo -----");
            Console.WriteLine();
        }

        /// <summary>
        /// 委托链：使用Combine和Remove
        /// </summary>
        private static void ChainDelegateDemo1()
        {
            Console.WriteLine("-----  Chain delegate demo1 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            DelegateDemo p = new DelegateDemo();
            Feedback fb3 = new Feedback(p.FeedbackToFile);


            Feedback fbchain = null;
            fbchain = (Feedback) Delegate.Combine(fbchain, fb1);
            fbchain = (Feedback)Delegate.Combine(fbchain, fb2);
            fbchain = (Feedback)Delegate.Combine(fbchain, fb3);

            Counter(1, 2, fbchain);
           


            fbchain=(Feedback)Delegate.Remove(fbchain, new Feedback(FeedbackToMsgBox));

            Counter(1, 2, fbchain);

            Console.WriteLine("----- end  Chain delegate demo1 -----");


            Console.WriteLine();
        }

        /// <summary>
        /// 委托链：使用+=和-=
        /// </summary>
        private static void ChainDelegateDemo2()
        {

            Console.WriteLine("-----  Chain delegate demo2 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            DelegateDemo p = new DelegateDemo();
            Feedback fb3 = new Feedback(p.FeedbackToFile);


            Feedback fbchain = null;
            fbchain +=  fb1;
            fbchain +=  fb2;
            fbchain +=  fb3;

            Counter(1, 2, fbchain);



            fbchain -=  FeedbackToMsgBox;

            Counter(1, 2, fbchain);

            Console.WriteLine("----- end  Chain delegate demo2 -----");


            Console.WriteLine();

        }

        private static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            for (int val= from; val < to; val++)
            {
                if (fb!=null)
                {
                    fb(val);
                }
            }
        }

        private static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Console Item={0}",value);
        }

        private static void FeedbackToMsgBox(Int32 value)
        {
            Console.WriteLine("Msg Item={0}", value);
        }

        private  void FeedbackToFile(int value)
        {
            Console.WriteLine("File Item={0}", value);
        }
    }

     
}
