namespace GAP.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GAP.Business.Messages;
    using GAP.Data.Model;
    
    public class PatientService : ServiceBase, IServiceCrud<PatientMessage>
    {
        public void Delete(Guid id)
        {
            try
            {
                var patientEntity = _db.Patient.Find(id);

                if (patientEntity != null)
                {
                    _db.Patient.Remove(patientEntity);
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PatientMessage GetById(Guid id)
        {
            PatientMessage patientMessage = new PatientMessage();

            try
            {
                if (id != Guid.Empty)
                {
                    var patientEntity = _db.Patient.Find(id);

                    if (patientEntity != null)
                    {
                        patientMessage = new PatientMessage
                        {
                            Id = patientEntity.Id,
                            Email = patientEntity.Email,
                            FirstName = patientEntity.FirstName,
                            LastName = patientEntity.LastName,
                            Identification = patientEntity.Identification,
                            IdentificationType = patientEntity.IdentificationType,
                            Telephone = patientEntity.Telephone
                        };
                    }
                }

                return patientMessage;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PatientMessage> GetList()
        {
            List<PatientMessage> listPatientMessage = new List<PatientMessage>();

            try
            {
                var patientEntity = _db.Patient.ToList();

                if (patientEntity?.Count > 0)
                {
                    foreach (var item in patientEntity)
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
                }

                return listPatientMessage;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save(PatientMessage message)
        {
            try
            {
                Patient patientEntity = new Patient
                {
                    Email = message.Email,
                    FirstName = message.FirstName,
                    LastName = message.LastName,
                    Identification = message.Identification,
                    IdentificationType = message.IdentificationType,
                    Telephone = message.Telephone
                };

                if (message.Id == Guid.Empty)
                {
                    patientEntity.Id = Guid.NewGuid();
                    _db.Patient.Add(patientEntity);
                }
                else
                    _db.Entry(patientEntity).State = System.Data.Entity.EntityState.Modified;

                _db.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }        
    }
}
