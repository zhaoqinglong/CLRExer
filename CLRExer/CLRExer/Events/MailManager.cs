using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CLRExer.Events
{
    public class MailManager
    {
        /// <summary>
        /// 定义事件成员
        /// </summary>
        public event EventHandler<NewMailEventArgs> NewMail;

        //定义负责引发事件的方法来通知已登记的对象
        public virtual void OnNewMail(NewMailEventArgs e)
        {
            //出于线程安全的考虑，现在对委托字段的引用复制到临时字段
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);

            //任何方法登记了对事件的关注就通知他们
            //if (temp != null )
            //    temp(this, e);
            
            temp?.Invoke(this,e);
        }

        //定义方法将输入转化为期望的事件
        public void SimulateNewMail(string from, string to, string subject)
        {

            NewMailEventArgs e=new NewMailEventArgs(from,to,subject);

            //4、调用虚方法通知对象事件已发生
            OnNewMail(e);
        }
    }
}
