using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessTweets;

namespace Tests
{
    [TestClass]
    public class UserHelperTests
    {
        [TestMethod]
        [TestCategory("UserHelpers")]
        public void GetAllUsersInLineReturnsExpectedOutput()
        {
            string input = "Aman follows Alonso, Kimi, Vettel, Verstappen, Hamilton";
            string [] expectedOutput = { "Aman", "Alonso", "Kimi", "Vettel", "Verstappen", "Hamilton" };
            var output = UserHelper.GetAllUsersInLine(input);
            Assert.IsNotNull(output);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        [TestCategory("UserHelpers")]
        public void GetAllUsersInLineReturnsInvalidOutput()
        {
            string input = "Aman followed Alonso, Kimi, Vettel, Verstappen, Hamilton";
            string[] expectedOutput = { "Aman", "Alonso", "Kimi", "Vettel", "Verstappen", "Hamilton" };
            var output = UserHelper.GetAllUsersInLine(input);
            Assert.IsNotNull(output);
            Assert.AreNotEqual(expectedOutput, output);
        }

      

    }
}
