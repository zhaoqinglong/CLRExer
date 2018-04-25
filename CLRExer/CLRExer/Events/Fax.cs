using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.Events
{
  internal  sealed class Fax
    {
        public Fax(MailManager mm)
        {
            //订阅事件
            mm.NewMail += FaxMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">表示MailManager对象</param>
        /// <param name="e">表示MailManager对象想传给我们的信息</param>
        private void FaxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail Message");
            Console.WriteLine("From={0},To={1},Subject={2}",e.From,e.To,e.Subject);
        }

        /// <summary>
        /// Fax对象向NewMail事件注销自己对它的关注
        /// </summary>
        /// <param name="mm"></param>
        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }
}
