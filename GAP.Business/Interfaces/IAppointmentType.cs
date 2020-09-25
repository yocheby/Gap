namespace GAP.Business.Interfaces
{
    using System.Collections.Generic;

    public interface IAppointmentType<T>
    {
        List<T> GetList();
    }
}
