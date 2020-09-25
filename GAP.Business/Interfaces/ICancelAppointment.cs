using System;

namespace GAP.Business.Interfaces
{
    public interface ICancelAppointment
    {
        bool Cancel(Guid id, DateTime cancelDate);
    }
}
