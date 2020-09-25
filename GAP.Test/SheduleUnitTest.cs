using System;
using GAP.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GAP.Test
{
    [TestClass]
    public class SheduleUnitTest
    {
        [TestMethod]
        public void DifferentDayTest()
        {
            // Arrange.
            DateTime dateTimeDb = DateTime.Now;
            DateTime dateTimeShedule = dateTimeDb.AddDays(30);

            // Act.
            AppointmentDuplicatesService appointmentDuplicatesService = new AppointmentDuplicatesService();
            var isSameDay = appointmentDuplicatesService.IsSameDay(dateTimeDb, dateTimeShedule);

            // Assert.
            Assert.IsFalse(isSameDay);
        }

        [TestMethod]
        public void SameDayTest()
        {
            // Arrange.
            DateTime dateTimeDb = DateTime.Now;
            DateTime dateTimeShedule = dateTimeDb;

            // Act.
            AppointmentDuplicatesService appointmentDuplicatesService = new AppointmentDuplicatesService();
            var isSameDay = appointmentDuplicatesService.IsSameDay(dateTimeDb, dateTimeShedule);

            // Assert.
            Assert.IsTrue(isSameDay);
        }
    }
}
