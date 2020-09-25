namespace GAP.Business.Global
{
    public enum DataBaseEngine
    {
        SqlServer = 1,

        Oracle = 2,

        MongoDb = 3
    }

    public enum IdentificationType
    {
        Passport = 0,

        NationalDocument = 1
    }

    public enum StateAppointment
    {
        Sheduled = 1, 

        Canceled = 2
    }

    public enum AppointmentType
    {
        General = 1,

        Odontology = 2,

        Pediatrics = 3,

        Neurological = 4
    }
}
