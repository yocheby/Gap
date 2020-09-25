namespace GAP.Business.Services
{
    using System.Linq;
    using GAP.Business.Interfaces;

    public class PatientDuplicatesService : ServiceBase, IDuplicates
    {
        public int IdentificationType { get; set; }

        public string IdentificationNumber { get; set; }

        public bool Exist()
        {
            if (IdentificationNumber == default || IdentificationNumber == default)
                return false;

            var patientEntity = _db.Patient.Where(p => p.IdentificationType == IdentificationType && 
            p.Identification == IdentificationNumber).FirstOrDefault();

            return patientEntity != null;
        }
    }
}
