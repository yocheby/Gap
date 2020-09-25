using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GAP.Business.Messages
{
    public class PatientMessage
    {
        public System.Guid Id { get; set; }

        [DisplayName("Nombres")]
        [Required]
        [MaxLength(50, ErrorMessage = "Número excede el máximo permitido")]
        public string FirstName { get; set; }

        [DisplayName("Apellidos")]
        [Required]
        [MaxLength(50, ErrorMessage = "Número excede el máximo permitido")]
        public string LastName { get; set; }

        [DisplayName("Tipo documento")]
        [Required]
        public int IdentificationType { get; set; }

        [DisplayName("Identificación")]
        [Required]
        [MaxLength(50, ErrorMessage = "Número excede el máximo permitido")]
        public string Identification { get; set; }

        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Número excede el máximo permitido")]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        [MaxLength(50, ErrorMessage = "Número excede el máximo permitido")]
        public string Telephone { get; set; }
    }
}
