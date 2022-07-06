using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NormalEmail()
        {
            ClassLibrary2.Class1 c = new ClassLibrary2.Class1();

            Assert.AreEqual(true, c.IsEmailOK("aaa@cc.com"),"Oh no");
  
        }
        [TestMethod]
        public void InvalidEmail()
        {
            ClassLibrary2.Class1 c = new ClassLibrary2.Class1();

           
            Assert.AreEqual(false, c.IsEmailOK("aacc.com"), "Oh no");
            

        }
        [TestMethod]
        public void LongEmail()
        {
            ClassLibrary2.Class1 c = new ClassLibrary2.Class1();

            Assert.AreEqual(true, c.IsEmailOK("a.sfff.e.e.eaa@c3333-c.c-om.au"), "Oh no");


        }

        [TestMethod]
        public void EmailwithWeirdCharacter()
        {
            ClassLibrary2.Class1 c = new ClassLibrary2.Class1();

            Assert.AreEqual(false, c.IsEmailOK("jjs%%k@swe.com"), "Oh no");


        }
    }
}
