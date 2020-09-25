namespace GAP.Business.Services
{
    using System;
    using GAP.Business.Global;
    using GAP.Business.Interfaces;

    public class CancelerService : ServiceBase, ICancelAppointment
    {
        private readonly int _hoursBefore = 24;

        public bool Cancel(Guid id, DateTime cancelDate)
        {
            var appointment = _db.Appointment.Find(id);

            if (appointment != null)
            {
                if(IsValidToCancel(appointment.Date, cancelDate))
                {
                    appointment.State = (int)StateAppointment.Canceled;
                    _db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public bool IsValidToCancel(DateTime appointmentDate, DateTime appointmentDateCancel)
        {            
            return appointmentDateCancel.AddHours(_hoursBefore) <= appointmentDate;
        }
    }
}
