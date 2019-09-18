using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TASKWebApp.Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountGenderShouldReturn3()
        {
            Assert.AreEqual(3, Business.Helpers.ComboBoxDataLoader.Gender.Values.Count);
        }
    }
}
