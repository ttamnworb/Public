using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidation.Tests
{
    [TestClass()]
    public class PasswordValidationTests
    {
        [TestMethod()]
        public void PasswordValidationTest1()
        {
            // 1. The password must be at least 8 characters long. If it is not met, then the following error message should be returned: “Password must be at least 8 characters”
            Assert.IsTrue(Password.Validate("ABCDEF").Contains("Password must be at least 8 characters"));
        }

        [TestMethod()]
        public void PasswordValidationTest2()
        {
            // 2. The password must contain at least 2 numbers.If it is not met, then the following error message should be returned: “The password must contain at least 2 numbers”
            Assert.IsTrue(Password.Validate("ABCDEFG1").Contains("The password must contain at least 2 numbers"));
        }

        [TestMethod()]
        public void PasswordValidationTest3()
        {
            // 3. The validation function should handle multiple validation errors.
            //       For example, “somepassword” should an error message: “Password must be at least 8 characters\nThe password must contain at least 2 numbers”
            Assert.IsTrue(Password.Validate("ABCDE1").Contains("Password must be at least 8 characters\nThe password must contain at least 2 numbers"));
        }
 
        [TestMethod()]
        public void PasswordValidationTest4()
        {
            // 4. The password must contain at least one capital letter.If it is not met, then the following error message should be returned: “password must contain at least one capital letter”
            Assert.IsTrue(Password.Validate("abcdef12").Contains("password must contain at least one capital letter"));
        }
        [TestMethod()]
        public void PasswordValidationTest5()
        {
            // 5. The password must contain at least one special character.If it is not met, then the following error message should be returned: “password must contain at least one special character”
            Assert.IsTrue(Password.Validate("abcdef12").Contains("password must contain at least one special character"));
            Assert.AreEqual(string.Empty, Password.Validate("!Bcdef12"));
        }


    }
}