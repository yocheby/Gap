namespace GAP.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using GAP.Business.Messages;
    using GAP.Business.Services;

    public class AppointmentWebApiController : ApiController
    {
        // POST api/values
        public IEnumerable<PatientMessage> Post(PatientFilterMessage patientFilterMessage)
        {
            PatientFilterService patientFilterService = new PatientFilterService();
            patientFilterService.Names = patientFilterMessage.Names.Trim();
            patientFilterService.Identification = patientFilterMessage.Identification.Trim();
            List<PatientMessage> listPatient = patientFilterService.GetList();

            return listPatient; 
        }
    }
}
