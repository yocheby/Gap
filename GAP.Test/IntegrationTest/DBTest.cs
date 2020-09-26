using System;
using GAP.Business.Global;
using GAP.Business.Messages;
using GAP.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GAP.Test.IntegrationTest
{
    [TestClass]
    public class DBTest
    {
        private readonly Guid IdPatient = new Guid("4DCBD4B9-D377-4749-88F1-3FA3793B0B08");

        [TestMethod]
        public void SavePatientTest()
        {
            PatientMessage patientMessage = new PatientMessage {
                FirstName = "Integration",
                LastName = "Test",
                Email = "test@gap.com",
                Identification = "123456",
                Telephone = "01800-9090",
                IdentificationType = (int)IdentificationType.NationalDocument
                
            };

            PatientService patientService = new PatientService();
            patientService.Save(patientMessage);
        }

        [TestMethod]
        public void SaveAppointmentTest()
        {
            AppointmentMessage appointmentMessage = new AppointmentMessage
            {

                Date = DateTime.Now,
                Id = Guid.Empty,
                IdAppointmentType = (int)AppointmentType.General,
                IdPatient = IdPatient
            };

            AppointmentService appointmentService = new AppointmentService();
            appointmentService.Save(appointmentMessage);
        }
    }
}
