using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Jurisdiction
    {
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
