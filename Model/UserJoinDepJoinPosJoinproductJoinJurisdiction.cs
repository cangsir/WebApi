using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserJoinDepJoinPosJoinproductJoinJurisdiction
    {
        /////////////UserInfo表
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
        public bool UserState { get; set; }

        /// <summary>
        /// 用户添加时间
        /// </summary>
        public string UserAddTime { get; set; }




        /////////////Department表
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }




        /////////////Position职位表
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
        public bool? PositionState { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string PositionAddTime { get; set; }




        /////////////product产品表
        /// <summary>
        /// 产品ID
        /// </summary>
        public int? PId   { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string PName { get; set; }




        /////////////Jurisdiction权限表
        /// <summary>
        /// 权限ID
        /// </summary>
        public int? JurisdictionId { get; set; }

        /// <summary>
        /// 用户权限：0:添加；1:删除；2:修改；3:停用；4:冻结；5:权限设置；6:导入；7:导出；
        /// </summary>
        public string JurisdictionUser { get; set; }

        /// <summary>
        /// 会议权限：0:添加；1:删除；2:修改；3:审批参会人员；4:分配名额；5:修改名额；6:统计会议；7:修改参会人员；8:下载资料；
        /// </summary>
        public string JurisdictionHuiyi { get; set; }

        /// <summary>
        /// 物料权限：0:添加；1:删除；2:修改；3:审批物料；4:发货；5:退单；6:统计物料；
        /// </summary>
        public string JurisdictionWuliao { get; set; }

        /// <summary>
        /// 活动权限：0:添加；1:删除；2:修改；3:审批活动；4:统计活动；5:下载资料；
        /// </summary>
        public string JurisdictionHuodong { get; set; }

        /// <summary>
        /// 公告权限：0:添加；1:删除；2:修改；
        /// </summary>
        public string JurisdictionGonggao { get; set; }

        /// <summary>
        /// 数据权限：0:个人,只能操作自己和下属的数据；1:所属部门,能操作自己、下属、和自己所属部门的数据；2:全公司,能操作全公司的数据；
        /// </summary>
        public string JurisdictionData { get; set; }

        /// <summary>
        /// 职位ID
        /// </summary>
        public int? J_PositionId { get; set; }
    }
}
