using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data.SqlClient;
using Model;
using System.Data;
using Newtonsoft.Json;

namespace DAL
{
    public class MeeTingDal : InterfaceMeeTingDal
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public int Login(UserInfo userInfo)
        {
            //创建单个参数
            SqlParameter para = new SqlParameter("@CountRow", SqlDbType.Int);
            //表名这个参数是输出参数
            para.Direction = ParameterDirection.Output;

            //创建存储过程参数
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@UserName",userInfo.UserName),
                new SqlParameter("@UserPwd",userInfo.UserPassword),
                para
            };

            object obj = SqlDbHelper.ExecuteScalarByProc("sp_Login", parameters);

            int count = Convert.ToInt32(para.Value);

            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }



            //if (Convert.ToInt32(SqlDbHelper.ExecuteScalarByProc("sp_Login", parameters)) != 0)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 1;
            //}
        }

        /// <summary>
        /// 用户列表显示
        /// </summary>
        /// <returns></returns>
        public List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoins()
        {
            List<UserJoinDepJoinPosJoinproductJoinJurisdiction> userJoin = new List<UserJoinDepJoinPosJoinproductJoinJurisdiction>();
            string sqlText = "SELECT * FROM dbo.UserInfo u LEFT JOIN dbo.Department d ON u.U_DepartmentId = d.DepartmentId LEFT JOIN dbo.Position po ON u.U_PositionId = po.PositionId LEFT JOIN dbo.Jurisdiction j ON po.PositionId = j.J_PositionId LEFT JOIN dbo.product pr ON u.ProductTeam = pr.PId";
            //DataTable data = new DataTable();
            //data = SqlDbHelper.ExecuteDataTable(sqlText);
            userJoin = JsonConvert.DeserializeObject<List<UserJoinDepJoinPosJoinproductJoinJurisdiction>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            //截取时间
            foreach (var item in userJoin)
            {
                string dt = item.UserAddTime;

                string date = dt.Substring(0, 10);
                string time = dt.Substring(11, 5);

                string datatime = $"{date}   {time}";

                item.UserAddTime = datatime;
            }

            return userJoin;
        }


        /// <summary>
        /// 根据Id显示用户列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoinsById(int userId)
        {
            List<UserJoinDepJoinPosJoinproductJoinJurisdiction> userJoin = new List<UserJoinDepJoinPosJoinproductJoinJurisdiction>();
            string sqlText = $"SELECT * FROM dbo.UserInfo u LEFT JOIN dbo.Department d ON u.U_DepartmentId = d.DepartmentId LEFT JOIN dbo.Position po ON u.U_PositionId = po.PositionId LEFT JOIN dbo.Jurisdiction j ON po.PositionId = j.J_PositionId LEFT JOIN dbo.product pr ON u.ProductTeam = pr.PId WHERE u.UserId = {userId}";
            //DataTable data = new DataTable();
            //data = SqlDbHelper.ExecuteDataTable(sqlText);
            userJoin = JsonConvert.DeserializeObject<List<UserJoinDepJoinPosJoinproductJoinJurisdiction>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            //截取时间
            foreach (var item in userJoin)
            {
                string dt = item.UserAddTime;

                string date = dt.Substring(0, 10);
                string time = dt.Substring(11, 5);

                string datatime = $"{date}   {time}";

                item.UserAddTime = datatime;
            }

            return userJoin;
        }

        /// <summary>
        /// 根据UserName显示用户列表
        /// </summary>
        /// <returns></returns>
        public List<UserJoinDepJoinPosJoinproductJoinJurisdiction> GetUserJoinsByIUserName(string userName)
        {
            List<UserJoinDepJoinPosJoinproductJoinJurisdiction> userJoin = new List<UserJoinDepJoinPosJoinproductJoinJurisdiction>();
            string sqlText = $"SELECT * FROM dbo.UserInfo u LEFT JOIN dbo.Department d ON u.U_DepartmentId = d.DepartmentId LEFT JOIN dbo.Position po ON u.U_PositionId = po.PositionId LEFT JOIN dbo.Jurisdiction j ON po.PositionId = j.J_PositionId LEFT JOIN dbo.product pr ON u.ProductTeam = pr.PId WHERE u.UserName = {userName}";
            //DataTable data = new DataTable();
            //data = SqlDbHelper.ExecuteDataTable(sqlText);
            userJoin = JsonConvert.DeserializeObject<List<UserJoinDepJoinPosJoinproductJoinJurisdiction>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            //截取时间
            foreach (var item in userJoin)
            {
                string dt = item.UserAddTime;

                string date = dt.Substring(0, 10);
                string time = dt.Substring(11, 5);

                string datatime = $"{date}   {time}";

                item.UserAddTime = datatime;
            }

            return userJoin;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public int DelUser(int userid)
        {
            string sqlText = $"DELETE dbo.UserInfo WHERE UserId = {userid}";

            if (SqlDbHelper.ExecuteNonQuery(sqlText))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获取部门表
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            string sqlText = "SELECT * FROM dbo.Department";
            departments = JsonConvert.DeserializeObject<List<Department>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            return departments;
        }

        /// <summary>
        /// 获取职位表
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPositions()
        {
            List<Position> positions = new List<Position>();
            string sqlText = "SELECT * FROM dbo.Position";
            positions = JsonConvert.DeserializeObject<List<Position>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            //截取时间
            foreach (var item in positions)
            {
                string dt = item.PositionAddTime;

                string date = dt.Substring(0, 10);
                string time = dt.Substring(11, 5);

                string datatime = $"{date}   {time}";

                item.PositionAddTime = datatime;
            }

            return positions;
        }

        /// <summary>
        /// 根据ID获取职位表
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPositionsById(int positionId)
        {
            List<Position> positions = new List<Position>();
            string sqlText = $"SELECT * FROM dbo.Position WHERE PositionId = '{positionId}'";
            positions = JsonConvert.DeserializeObject<List<Position>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            //截取时间
            foreach (var item in positions)
            {
                string dt = item.PositionAddTime;

                string date = dt.Substring(0, 10);
                string time = dt.Substring(11, 5);

                string datatime = $"{date}   {time}";

                item.PositionAddTime = datatime;
            }

            return positions;
        }

        /// <summary>
        /// 获取职位和权限表
        /// </summary>
        /// <returns></returns>
        public List<PositionJoinJurisdiction> GetPositionsJoinJurisdiction()
        {
            List<PositionJoinJurisdiction> posjoinjur = new List<PositionJoinJurisdiction>();
            string sqlText = $"SELECT * FROM dbo.Position p LEFT JOIN dbo.Jurisdiction j ON p.PositionId = j.J_PositionId";
            posjoinjur = JsonConvert.DeserializeObject<List<PositionJoinJurisdiction>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            return posjoinjur;
        }

        /// <summary>
        /// 获取职位和权限表
        /// </summary>
        /// <returns></returns>
        public List<PositionJoinJurisdiction> GetPositionsJoinJurisdictionBypPosId(int positionId)
        {
            List<PositionJoinJurisdiction> posjoinjur = new List<PositionJoinJurisdiction>();
            string sqlText = $"SELECT * FROM dbo.Position p LEFT JOIN dbo.Jurisdiction j ON p.PositionId = j.J_PositionId WHERE j.J_PositionId = '{positionId}'";
            posjoinjur = JsonConvert.DeserializeObject<List<PositionJoinJurisdiction>>(JsonConvert.SerializeObject(SqlDbHelper.ExecuteDataTable(sqlText)));

            return posjoinjur;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int AddUserInfo(UserInfo userInfo)
        {
            string sqlText = $"INSERT INTO UserInfo VALUES('{userInfo.UserName}', '{userInfo.Name}', '{userInfo.UserPassword}', '{userInfo.Email}', '{userInfo.U_DepartmentId}', '{userInfo.U_PositionId}', '{userInfo.ProductTeam}', '', '', '0', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}')";
            if (SqlDbHelper.ExecuteNonQuery(sqlText))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UptUserInfo(UserInfo user)
        {
            string sqlText = $"UPDATE dbo.UserInfo SET UserName = '{user.UserName}', Name = '{user.Name}', UserPassword = '{user.UserPassword}', Email = '{user.Email}', U_DepartmentId = '{user.U_DepartmentId}', U_PositionId = '{user.U_PositionId}', ProductTeam = '{user.ProductTeam}', UserAddTime = GETDATE() WHERE UserId = '{user.UserId}'";
            if (SqlDbHelper.ExecuteNonQuery(sqlText))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="userid">职位ID</param>
        /// <returns></returns>
        public int DelPosition(int positionid)
        {
            //创建存储过程参数
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@PositionId", positionid)
            };

            if (SqlDbHelper.ExecuteNonQueryByProc("sp_DelPosition", parameters))
            {
                return 0;
            }
            else
            {
                return 1;
            }

            //string sqlText = $"DELETE dbo.Position WHERE PositionId = {positionid}";

            //if (SqlDbHelper.ExecuteNonQuery(sqlText))
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 1;
            //}
        }

        /// <summary>
        /// 修改职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int UptPosition(Position position)
        {
            string sqlText = $"UPDATE dbo.Position SET PositionName = '{position.PositionName}', PositionDescribe = '{position.PositionDescribe}' WHERE PositionId = '{position.PositionId}'";

            if (SqlDbHelper.ExecuteNonQuery(sqlText))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int AddPosition(Position position)
        {
            //创建存储过程参数
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@PositionName", position.PositionName),
                new SqlParameter("@PositionDescribe", position.PositionDescribe)
            };

            if (SqlDbHelper.ExecuteNonQueryByProc("sp_AddPosition", parameters))
            {
                return 0;
            }
            else
            {
                return 1;
            }



            //string sqlText = $"INSERT INTO Position VALUES('{position.PositionName}', '{position.PositionDescribe}', '0', GETDATE())";

            //if (SqlDbHelper.ExecuteNonQuery(sqlText))
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        /// <summary>
        /// 修改/设置权限
        /// </summary>
        /// <param name="jurisdiction"></param>
        /// <returns></returns>
        public int UptJurisdiction(Jurisdiction jur)
        {
            string sqlText = $"UPDATE dbo.Jurisdiction SET JurisdictionUser = '{jur.JurisdictionUser}', JurisdictionHuiyi = '{jur.JurisdictionHuiyi}', JurisdictionWuliao = '{jur.JurisdictionWuliao}', JurisdictionHuodong = '{jur.JurisdictionHuodong}', JurisdictionGonggao = '{jur.JurisdictionGonggao}', JurisdictionData = '{jur.JurisdictionData}' WHERE J_PositionId = '{jur.J_PositionId}'";

            if (SqlDbHelper.ExecuteNonQuery(sqlText))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 停用/启用用户
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public int UptUserState(string userIds)
        {
            string sqlText = $"UPDATE dbo.UserInfo SET UserState = UserState - 1 WHERE UserId IN ({userIds})";

            if (SqlDbHelper.ExecuteNonQuery(sqlText))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

    }
}
