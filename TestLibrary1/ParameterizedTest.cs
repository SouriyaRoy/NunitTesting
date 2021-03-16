using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day1;

namespace TestLibrary1
{
    [TestFixture, Category("UserViewModel")]
    class ParameterizedTest
    {
        //[TestCase("abcgdefg",false, TestName = "TEst1")]
        //[TestCase("12345", false)]
        //[TestCase("abcg890", false)]
        //[TestCase("abcg12345@", true)]
        //public void TestPassWord(string pwd, bool ExpRes)
        //{
        //    UserViewModel uv = new UserViewModel();
        //    var res = uv.TestPassword(pwd);
        //    Assert.AreEqual(ExpRes, res);
        //}



        //public void TestPassWord(string pwd, bool ExpRes)
        //{
        //    UserViewModel uv = new UserViewModel();
        //    var res = uv.TestPassword(pwd);
        //    Assert.AreEqual(ExpRes, res);
        //}
        public static IEnumerable<TestCaseData> init()
        {
            yield return new TestCaseData("acbcd", false).SetName("Only Chars").SetCategory("Cat1");
            yield return new TestCaseData("1234", false).SetName("Only Digits").SetCategory("Cat1");
            yield return new TestCaseData("abc123%$", true).SetName("Correct Input").SetCategory("Cat1");
        }

        [TestCaseSource("init")]
        public void TestPassword(string pwd, bool ExpResult)
        {
            UserViewModel vm = new UserViewModel();
            var Result = vm.TestPassword(pwd);
            Assert.AreEqual(ExpResult, Result);
        }
        //[TestCaseSource("init")]
        //public void Test11(string pwd, bool ExpRes)
        //{

        //}



        //[Test]
        //public void TestpassWord_MinLength()
        //{
        //    UserViewModel uv = new UserViewModel();
        //    var res = uv.TestPassword("");
        //    Assert.IsFalse(res);
        //}

        //[Test]
        //public void TestpassWord_MaxLength()
        //{
        //    UserViewModel uv = new UserViewModel();
        //    var res = uv.TestPassword("gghghghghghgghghghghghghghghg");
        //    Assert.IsFalse(res);
        //}

        //[Test]
        //public void TestPass()
        //{
        //    UserViewModel uv = new UserViewModel();
        //    var result = uv.EncodePassword("Password123");
        //    Assert.IsTrue(result.Length > 15);
        //}

        //[Test]
        //public void TestPass2()
        //{
        //    UserViewModel uv = new UserViewModel();
        //    var result = uv.EncodePassword("Password123");
        //    Assert.IsTrue(result.Length < 5);
        //}
    }
}
