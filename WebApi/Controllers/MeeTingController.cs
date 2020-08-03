using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;
using NPOI.SS.Formula.Functions;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeeTingController : ControllerBase
    {
        private InterfaceMeeTingDal _dal;

        public MeeTingController(InterfaceMeeTingDal dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public int Login([FromForm]UserInfo userInfo)
        {
            return _dal.Login(userInfo);
        }

        /// <summary>
        /// 用户列表显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoins()
        {
            return _dal.GetUserJoins();
        }

        /// <summary>
        /// 根据Id显示用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoinsById(int userId)
        {
            return _dal.GetUserJoinsById(userId);
        }

        /// <summary>
        /// 根据UserName显示用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoinsByIUserName(string userName)
        {
            return _dal.GetUserJoinsByIUserName(userName);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public int DelUser(int userId)
        {
            return _dal.DelUser(userId);
        }

        /// <summary>
        /// 获取部门表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Department> GetDepartments()
        {
            return _dal.GetDepartments();
        }

        /// <summary>
        /// 获取职位表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Position> GetPositions()
        {
            return _dal.GetPositions();
        }

        /// <summary>
        /// 根据ID获取职位表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Position> GetPositionsById(int positionId)
        {
            return _dal.GetPositionsById(positionId);
        }

        /// <summary>
        /// 获取职位和权限表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PositionJoinJurisdiction> GetPositionsJoinJurisdiction()
        {
            return _dal.GetPositionsJoinJurisdiction();
        }


        /// <summary>
        /// 获取职位和权限表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PositionJoinJurisdiction> GetPositionsJoinJurisdictionBypPosId(int positionId)
        {
            return _dal.GetPositionsJoinJurisdictionBypPosId(positionId);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddUserInfo([FromForm] UserInfo userInfo)
        {
            return _dal.AddUserInfo(userInfo);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public int UptUserInfo([FromForm] UserInfo userInfo)
        {
            return _dal.UptUserInfo(userInfo);
        }

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="userId">职位ID</param>
        /// <returns></returns>
        [HttpGet]
        public int DelPosition(int positionid)
        {
            return _dal.DelPosition(positionid);
        }

        /// <summary>
        /// 修改职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public int UptPosition([FromHeader] Position position)
        {
            return _dal.UptPosition(position);
        }

        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddPosition([FromHeader] Position position)
        {
            return _dal.AddPosition(position);
        }

        /// <summary>
        /// 修改/设置权限
        /// </summary>
        /// <param name="jurisdiction"></param>
        /// <returns></returns>
        [HttpPost]
        public int UptJurisdiction([FromHeader] Jurisdiction jur)
        {
            return _dal.UptJurisdiction(jur);
        }

        /// <summary>
        /// 停用/启用用户
        /// </summary>
        /// <param name="jurisdiction"></param>
        /// <returns></returns>
        [HttpGet]
        public int UptUserState(string userIds)
        {
            return _dal.UptUserState(userIds);
        }


        /// <summary>
        /// 测试一
        /// </summary>
        /// <returns></returns>
        public int CeshiOne()
        {
            return 666;
        }
    }
}
