using GAP.Business.Messages;
using GAP.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.WebApi.Controllers
{
    public class AppointmentWebApiController : ApiController
    {
        // GET api/values
        public IEnumerable<PatientMessage> Get()
        {
            PatientService patientService = new PatientService();
            List<PatientMessage> listPatient = patientService.GetList();

            return listPatient; 
        }
    }
}
