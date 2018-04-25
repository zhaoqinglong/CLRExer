using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class NewMailEventArgs : EventArgs
    {

        //定义类型来容纳所有需要发送给事件通知接收者的附加信息

        private readonly string m_from, m_to, m_subject;

        public NewMailEventArgs(string from, string to, string subject)
        {
            m_from = from;
            m_to = to;
            m_subject = subject;
        }

        /// <summary>
        /// 
        /// </summary>
        public string From
        {
            get { return m_from; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string To
        {
            get { return m_to; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Subject
        {
            get { return m_subject; }
        }
    }
}
