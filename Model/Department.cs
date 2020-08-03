using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartmentId   { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
