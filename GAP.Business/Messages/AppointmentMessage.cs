namespace GAP.Business.Messages
{
    public class AppointmentMessage
    {
        public System.Guid Id { get; set; }
        public System.Guid IdPatient { get; set; }
        public int IdAppointmentType { get; set; }
        public System.DateTime Date { get; set; }
        public int State { get; set; }
    }
}
