using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Model.UserInfo user=new Model.UserInfo{ UserName="Admin",PassWord="abc.123" };
            Console.WriteLine(DAL.UserInfo.UserCheck(user));
        }
        [TestMethod]
        public void TestMethod2()
        {
            var model = DAL.UserInfo.GetModel("Admin");
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Model.UserInfo user = new Model.UserInfo { UserName = "Guest", PassWord = "sql.123", Type = "π‹¿Ì‘±" };
            Console.WriteLine(DAL.UserInfo.Add(user));
            user.QQ = "104512708";
            Console.WriteLine(DAL.UserInfo.Update(user));
            Console.WriteLine(DAL.UserInfo.Delete("Guest"));
        }
    }
}
