using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 职位表
    /// </summary>
    public class Position
    {
        /// <summary>
        /// 职位ID
        /// </summary>
        public int? PositionId { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 职位描述
        /// </summary>
        public string PositionDescribe { get; set; }

        /// <summary>
        /// 职位状态
        /// </summary>
        public bool PositionState { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string PositionAddTime { get; set; }
    }
}
