namespace GAP.Business.Messages
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AppointmentMessage
    {
        public System.Guid Id { get; set; }

        [DisplayName("Paciente")]
        [Required]
        public System.Guid IdPatient { get; set; }

        [DisplayName("Paciente")]
        public string FullNamePatient { get; set; }

        [DisplayName("Tipo de cita")]
        [Required]
        public int IdAppointmentType { get; set; }

        [DisplayName("Tipo de cita")]
        public string NameAppointmentType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de cita")]
        [Required]
        public System.DateTime Date { get; set; }

        [DisplayName("Estado")]
        public int State { get; set; }

        [DisplayName("Estado")]
        public string NameState { get; set; }
    }
}
