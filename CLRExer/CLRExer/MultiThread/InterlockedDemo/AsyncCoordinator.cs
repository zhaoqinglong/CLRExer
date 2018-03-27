using System;
using System.Threading;

namespace CLRExer.MultiThread.InterlockedDemo
{
    public enum CoordinationStatus
    {
        AllDone,
        Timeout,
        Cancel
    }

    public class AsyncCoordinator
    {
        private Int32 m_opCount = 1;
        private Int32 m_statusReported = 0;
        private Action<CoordinationStatus> m_callback;
        private Timer m_timer;

        /// <summary>
        /// 该方法在发起一个操作之前调用
        /// </summary>
        /// <param name="opsToAdd"></param>
        public void AboutToBegin(int opsToAdd = 1)
        {
            //加1
            Interlocked.Add(ref m_opCount, opsToAdd);
        }

        /// <summary>
        /// 该方法在处理好一个操作的结果之后调用
        /// </summary>
        public void JustEnded()
        {
            //自减1，并返回结果
            if (Interlocked.Decrement(ref m_opCount) == 0)
                ReportStatus(CoordinationStatus.AllDone);
        }

        /// <summary>
        /// 该方法在发起所有操作后调用
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="timeout"></param>
        public void AllBegun(Action<CoordinationStatus> callback, int timeout = Timeout.Infinite)
        {
            m_callback = callback;
            if (timeout != Timeout.Infinite)
            {
                m_timer = new Timer(TimeExpired, null, timeout, Timeout.Infinite);
            }
            JustEnded();

        }

        public void Cancel()
        {
            ReportStatus(CoordinationStatus.Cancel);
        }


        private void TimeExpired(object o)
        {
            ReportStatus(CoordinationStatus.Timeout);
        }

        private void ReportStatus(CoordinationStatus status)
        {
            //如果状态从未报告就报告他，否则忽略
            if (Interlocked.Exchange(ref m_statusReported, 1) == 0)
                m_callback(status);
        }

    }
}
