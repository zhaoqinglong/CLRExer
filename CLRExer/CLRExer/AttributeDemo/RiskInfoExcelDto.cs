using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLRExer.AttributeDemo;


namespace YTOS.CoalSafe.Application.RiskClosedLoops.Dtos
{
    /// <summary>
    /// 
    /// </summary>
   
    [ExcelHead("隐患信息")]
    public class RiskInfoExcelDto
    {
        /// <summary>
        /// 隐患编号
        /// </summary>
        [ExcelHead("隐患编号")]
        public string RiskNum { set; get; }

        /// <summary>
        /// 风险值
        /// </summary>
        [ExcelHead("风险值")]
        public int RiskValue { set; get; }

        /// <summary>
        /// 分数/区队值
        /// </summary>
        [ExcelHead("分数")]
        public int Score { set; get; }

        /// <summary>
        /// 风险类型
        /// </summary>
        [ExcelHead("风险类型")]
        public string RiskType { set; get; }

        /// <summary>
        /// 所属区队
        /// </summary>
        [ExcelHead("所属区队")]
        public string BelongTeam { set; get; }

        /// <summary>
        /// 隐患名称
        /// </summary>
        [ExcelHead("隐患名称")]
        public string RiskName { set; get; }

        /// <summary>
        /// 专业
        /// </summary>
        [ExcelHead("专业")]
        public string Profession { set; get; }

        /// <summary>
        /// 检查人
        /// </summary>
        [ExcelHead("检查人")]
        public string Checker { set; get; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [ExcelHead("发布时间")]
        public DateTime? PublishTime { set; get; }

        /// <summary>
        /// 整改状态
        /// </summary>
        [ExcelHead("整改状态")]
        public string CorrectionState { set; get; }

        /// <summary>
        /// 整改期限
        /// </summary>
        [ExcelHead("整改期限")]
        public string CorrectionLimit { set; get; }

        /// <summary>
        /// 整改时间
        /// </summary>
        [ExcelHead("整改时间")]
        public DateTime? CorrectionTime { set; get; }

        /// <summary>
        /// 整改情况
        /// </summary>
        [ExcelHead("整改情况")]
        public string CorrectionDesc { set; get; }

        /// <summary>
        /// 跟踪复查人
        /// </summary>
        [ExcelHead("跟踪复查人")]
        public string Reviewer { set; get; }

        /// <summary>
        /// 复查时间
        /// </summary>
        [ExcelHead("复查时间")]
        public DateTime? ReviewTime { set; get; }
    }
}
