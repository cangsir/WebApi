using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public interface InterfaceMeeTingDal
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        int Login(UserInfo userInfo);

        /// <summary>
        /// 用户列表显示
        /// </summary>
        /// <returns></returns>
        List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoins();

        /// <summary>
        /// 根据Id显示用户列表
        /// </summary>
        /// <returns></returns>
        List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoinsById(int userId);

        /// <summary>
        /// 根据UserName显示用户列表
        /// </summary>
        /// <returns></returns>
        List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoinsByIUserName(string userName);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        int DelUser(int userid);

        /// <summary>
        /// 获取部门表
        /// </summary>
        /// <returns></returns>
        List<Department> GetDepartments();

        /// <summary>
        /// 获取职位表
        /// </summary>
        /// <returns></returns>
        List<Position> GetPositions();

        /// <summary>
        /// 根据ID获取职位表
        /// </summary>
        /// <returns></returns>
        List<Position> GetPositionsById(int positionId);

        /// <summary>
        /// 获取职位和权限表
        /// </summary>
        /// <returns></returns>
        List<PositionJoinJurisdiction> GetPositionsJoinJurisdiction();

        /// <summary>
        /// 根据ID获取职位和权限表
        /// </summary>
        /// <returns></returns>
        List<PositionJoinJurisdiction> GetPositionsJoinJurisdictionBypPosId(int positionId);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        int AddUserInfo(UserInfo userInfo);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        int UptUserInfo(UserInfo userInfo);

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="userid">职位ID</param>
        /// <returns></returns>
        int DelPosition(int positionid);

        /// <summary>
        /// 修改职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        int UptPosition(Position position);

        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        int AddPosition(Position position);

        /// <summary>
        /// 修改/设置权限
        /// </summary>
        /// <param name="jurisdiction"></param>
        /// <returns></returns>
        int UptJurisdiction(Jurisdiction jurisdiction);

        /// <summary>
        /// 停用/启用用户
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        int UptUserState(string userIds);
    }
}
