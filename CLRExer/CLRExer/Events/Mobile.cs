using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.Events
{
  public  class Mobile
    {

        public Mobile(MailManager mm)
        {
            //订阅事件
            mm.NewMail += MobileMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">表示MailManager对象</param>
        /// <param name="e">表示MailManager对象想传给我们的信息</param>
        private void MobileMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Mobile mail Message");
            Console.WriteLine("From={0},To={1},Subject={2}", e.From, e.To, e.Subject);
        }

    }
}
