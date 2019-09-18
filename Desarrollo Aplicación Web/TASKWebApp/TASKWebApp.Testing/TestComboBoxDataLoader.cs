using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TASKWebApp.Testing
{
    [TestClass]
    public class TestComboBoxDataLoader
    {
        [TestMethod]
        public void GenderCountIsHigherThan0()
        {
            Assert.IsTrue(Business.Helpers.ComboBoxDataLoader.Gender.Values.Count > 0);
        }

        [TestMethod]
        public void RegionCountIsHigherThan0()
        {
            Assert.IsTrue(Business.Helpers.ComboBoxDataLoader.Region.Values.Count > 0);
        }

        [TestMethod]
        public void DayOfWeekCountIsEquals7()
        {
            Assert.AreEqual(7, Business.Helpers.ComboBoxDataLoader.DayOfWeek.Values.Count);
        }

        [TestMethod]
        public void MonthCountIsEquals12()
        {
            Assert.AreEqual(12, Business.Helpers.ComboBoxDataLoader.Month.Values.Count);
        }

        [TestMethod]
        public void TaskStatusCountIsHigherThan0()
        {
            Assert.IsTrue(Business.Helpers.ComboBoxDataLoader.TaskStatus.Values.Count > 0);
        }

        [TestMethod]
        public void ProvincesOfCoquimboEquals3()
        {
            Assert.AreEqual(3, Business.Helpers.ComboBoxDataLoader.GetProvicesByRegionId(5).Values.Count);
        }

        [TestMethod]
        public void CommunesOfChoapaEquals4()
        {
            Assert.AreEqual(4, Business.Helpers.ComboBoxDataLoader.GetCommuneByProvinceId(13).Values.Count);
        }

    }
}
