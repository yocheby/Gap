namespace GAP.Business.Services
{
    using System;
    using System.Linq;
    using GAP.Business.Global;
    using GAP.Business.Interfaces;

    public class AppointmentDuplicatesService : ServiceBase, IDuplicates
    {
        public Guid IdPatient { get; set; }

        public DateTime AppointmentDate { get; set; }

        public Guid IdAppointment { get; set; }

        public bool Exist()
        {
            if (IdPatient != Guid.Empty)
            {
                var listAppointmentEntity = _db.Appointment.
                    Where(a => a.IdPatient == IdPatient && a.State == (int)StateAppointment.Sheduled && a.Id != IdAppointment
                    && a.Date >= AppointmentDate
                    ).ToList();

                foreach (var appointmentEntity in listAppointmentEntity)
                {
                    if (appointmentEntity != null)
                    {
                        if (IsSameDay(appointmentEntity.Date, AppointmentDate))
                            return true;
                    }
                }
            }

            return false;
        }

        public bool IsSameDay(DateTime dateTimeDb, DateTime dateShedule)
        {
            return dateTimeDb.Year == dateShedule.Year && dateTimeDb.DayOfYear == dateShedule.DayOfYear;
        }
    }
}
