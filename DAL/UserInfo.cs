using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
//using System.Linq;
namespace DAL
{
    public class UserInfo
    {
        public static string cns = AppConfigurtaionServices.Configuration.GetConnectionString("cns");
        public static int? UserCheck(Model.UserInfo user)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select 1 from userinfo where username=@username and password=@password";
                return cn.ExecuteScalar<int?>(sql, user);
            }
        }
        public static Model.UserInfo GetModel(string UserName)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select * from userinfo where username=@username";
                return cn.QueryFirstOrDefault<Model.UserInfo>(sql,new {username=UserName });
            }
        }
        public static int Add(Model.UserInfo user)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "insert into UserInfo values(@UserName,@Password,@QQ,@Email,@Type,@UserImg);";
                return cn.Execute(sql, user);
            }
        }
        public static int Update(Model.UserInfo user)
        {
            using(IDbConnection cn=new MySqlConnection(cns))
            {                
                string sql = "update UserInfo set password=@Password,qq=@QQ,email=@Email,type=@Type,userimg=@UserImg where username=@UserName";
                return cn.Execute(sql, user);
            }
        }
        public static int Delete(string username)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "delete from UserInfo where username=@UserName";
                return cn.Execute(sql, new { username=username });
            }
        }
    }
}
