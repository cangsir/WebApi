using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 用户名(手机号)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPassword { get; set; }

        ///// <summary>
        ///// 工号
        ///// </summary>
        //public int JobNumber { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int? U_DepartmentId { get; set; }

        /// <summary>
        /// 职位ID
        /// </summary>
        public int? U_PositionId { get; set; }

        /// <summary>
        /// 产品组
        /// </summary>
        public string ProductTeam { get; set; }

        /// <summary>
        /// 分配参会名额
        /// </summary>
        public int? Participants { get; set; }

        /// <summary>
        /// 分配陪同名额
        /// </summary>
        public int? Accompanying { get; set; }

        /// <summary>
        /// 用户状态 0:可用；1:停用
        /// </summary>
        public bool UserState    { get; set; }

        /// <summary>
        /// 用户添加时间
        /// </summary>
        public string UserAddTime { get; set; }
    }
}
