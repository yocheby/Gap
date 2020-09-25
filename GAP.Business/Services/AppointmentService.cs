namespace GAP.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GAP.Business.Global;
    using GAP.Business.Messages;
    using GAP.Data.Model;
    
    public class AppointmentService : ServiceBase, IServiceCrud<AppointmentMessage>
    {
        public void Delete(Guid id)
        {
            try
            {
                var appointmentEntity = _db.Appointment.Find(id);

                if (appointmentEntity != null) { 
                    _db.Appointment.Remove(appointmentEntity);
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AppointmentMessage> GetList()
        {
            List<AppointmentMessage> listAppointmentMessage = new List<AppointmentMessage>();

            try
            {
                var appointmentEntity = _db.Appointment.ToList();

                if (appointmentEntity?.Count > 0)
                {
                    foreach (var item in appointmentEntity)
                        listAppointmentMessage.Add(new AppointmentMessage
                        {
                            Id = item.Id,
                            State = item.State,
                            Date = item.Date,
                            IdAppointmentType = item.IdAppointmentType,
                            IdPatient = item.IdPatient
                        });
                }

                return listAppointmentMessage;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AppointmentMessage GetById(Guid id)
        {
            AppointmentMessage appointmentMessage = new AppointmentMessage();

            try
            {
                if (id != Guid.Empty)
                {
                    var appointmentEntity = _db.Appointment.Find(id);

                    if(appointmentEntity != null)
                    {
                        appointmentMessage = new AppointmentMessage {
                            Id = appointmentEntity.Id,
                            Date = appointmentEntity.Date,
                            State = appointmentEntity.State,
                            IdAppointmentType = appointmentEntity.IdAppointmentType,
                            IdPatient = appointmentEntity.IdPatient
                        };
                    }
                }

                return appointmentMessage;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save(AppointmentMessage message)
        {
            try
            {
                Appointment appointmentEntity = new Appointment {
                    Date = message.Date,
                    IdAppointmentType = message.IdAppointmentType,
                    IdPatient = message.IdPatient
                };

                if (message.Id == Guid.Empty)
                {
                    appointmentEntity.Id = Guid.NewGuid();
                    appointmentEntity.State = (int)StateAppointment.Sheduled; 
                    _db.Appointment.Add(appointmentEntity);
                }
                else
                    _db.Entry(appointmentEntity).State = System.Data.Entity.EntityState.Modified;

                _db.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
