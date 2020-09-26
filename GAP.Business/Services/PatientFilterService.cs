namespace GAP.Business.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using GAP.Business.Interfaces;
    using GAP.Business.Messages;
    
    public class PatientFilterService : ServiceBase, IListType<PatientMessage>
    {
        public string Names { get; set; }

        public string Identification { get; set; }

        public List<PatientMessage> GetList()
        {
            List<PatientMessage> listPatientMessage = new List<PatientMessage>();
            List<Data.Model.Patient> patientsEntity = default;

            if (!string.IsNullOrEmpty(Names) && !string.IsNullOrEmpty(Identification))
            {
                patientsEntity = _db.Patient.Where(p => p.LastName.Contains(Names) && p.Identification.Contains(Identification)).ToList();
            }
            else if (!string.IsNullOrEmpty(Names) && string.IsNullOrEmpty(Identification))
            {
                patientsEntity = _db.Patient.Where(p => p.LastName.Contains(Names)).ToList();
            }
            else
            {
                patientsEntity = _db.Patient.Where(p => p.Identification.Contains(Identification)).ToList();
            }

            if (patientsEntity != default)
                foreach (var item in patientsEntity)
                    listPatientMessage.Add(new PatientMessage
                    {
                        Id = item.Id,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Identification = item.Identification,
                        IdentificationType = item.IdentificationType,
                        Telephone = item.Telephone
                    });

            return listPatientMessage;
        }
    }
}
