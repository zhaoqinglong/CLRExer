using System;
using System.Collections.Generic;
using System.Text;

namespace CLRExer.AttributeDemo
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class ExcelHeadAttribute : Attribute
    {
        /// <summary>
        /// 设置名称
        /// </summary>
        public string _name { get; set; }

        /// <summary>
        /// 单元格长度
        /// </summary>
        public int _length { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Length"></param>
        public ExcelHeadAttribute(string Name, int Length = 10)
        {
            _name = Name;
            _length = Length;
        }
    }
}
