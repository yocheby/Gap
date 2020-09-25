namespace GAP.Business.Messages
{
    public class PatientMessage
    {
        public System.Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdentificationType { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
