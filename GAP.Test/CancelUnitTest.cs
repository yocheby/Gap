using GAP.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GAP.Test
{
    [TestClass]
    public class CancelUnitTest
    {
        [TestMethod]
        public void HourAfterTest()
        {
            DateTime dateTimeDb = DateTime.Now;
            DateTime dateTimeCancel = DateTime.Now.AddHours(1);

            CancelerService cancelerAppointment = new CancelerService();
            var isValid = cancelerAppointment.IsValidToCancel(dateTimeDb, dateTimeCancel);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void HourBeforeTest()
        {
            // Arrange
            DateTime dateTimeDb = DateTime.Now;
            DateTime dateTimeCancel = dateTimeDb.AddHours(-30);

            // Act
            CancelerService cancelerAppointment = new CancelerService();
            var isValid = cancelerAppointment.IsValidToCancel(dateTimeDb, dateTimeCancel);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void HourOnTest()
        {
            DateTime dateTimeDb = DateTime.Now;
            DateTime dateTimeCancel = dateTimeDb.AddHours(-24);

            CancelerService cancelerAppointment = new CancelerService();
            var isValid = cancelerAppointment.IsValidToCancel(dateTimeDb, dateTimeCancel);

            Assert.IsTrue(isValid);
        }
    }
}
