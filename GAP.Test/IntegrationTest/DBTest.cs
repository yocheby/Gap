using System;
using System.Collections.Generic;
using GAP.Business.Global;
using GAP.Business.Messages;
using GAP.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GAP.Test.IntegrationTest
{
    [TestClass]
    public class DBTest
    {
        [TestMethod]
        public void SavePatientTest()
        {
            PatientMessage patientMessage = new PatientMessage {
                FirstName = "Integration"+ (new Random()).Next(),
                LastName = "Test",
                Email = "test@gap.com",
                Identification = "INT123",
                Telephone = "01800-9090",
                IdentificationType = (int)IdentificationType.NationalDocument
                
            };

            PatientService patientService = new PatientService();
            patientService.Save(patientMessage);
        }

        [TestMethod]
        public void SaveAppointmentTest()
        {
            PatientFilterService patientFilterService = new PatientFilterService();
            patientFilterService.Identification = "INT123";
            List<PatientMessage> listPatient = patientFilterService.GetList();

            if(listPatient?.Count > 0)
            {
                AppointmentMessage appointmentMessage = new AppointmentMessage
                {
                    Date = DateTime.Now,
                    Id = Guid.Empty,
                    IdAppointmentType = (int)AppointmentType.General,
                    IdPatient = listPatient[0].Id
                };

                AppointmentService appointmentService = new AppointmentService();
                appointmentService.Save(appointmentMessage);
            }
        }
    }
}
