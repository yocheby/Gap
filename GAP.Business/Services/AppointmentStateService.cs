namespace GAP.Business.Services
{
    using GAP.Business.Global;

    public static class AppointmentStateService
    {
        public static string GetNameById(int id)
        {
            switch (id)
            {
                case (int)StateAppointment.Sheduled:
                    return "Programada";
                case (int)StateAppointment.Canceled:
                    return "Cancelada";
                default:
                    return default;
            }
        }
    }
}
