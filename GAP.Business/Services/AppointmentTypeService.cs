namespace GAP.Business.Services
{
    using GAP.Business.Global;
    using GAP.Business.Messages;
    using System.Collections.Generic;

    public static class AppointmentTypeService
    {
        public static List<AppointmentTypeMessage> GetList()
        {
            List<AppointmentTypeMessage> listAppointmentTypeMessage = new List<AppointmentTypeMessage>();

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = (int)AppointmentType.General,
                Name = "Medicina General"
            });

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = (int)AppointmentType.Odontology,
                Name = "Odontología"
            });

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = (int)AppointmentType.Pediatrics,
                Name = "Pediatría"
            });

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = (int)AppointmentType.Neurological,
                Name = "Neurología"
            });

            // TODO: Sacar del config los valores.
            //System.Configuration.con ConfigurationManager


            return listAppointmentTypeMessage;
        }

        public static string GetNameById(int id)
        {
            switch (id)
            {
                case (int)AppointmentType.General:
                    return "Medicina General";
                case (int)AppointmentType.Odontology:
                    return "Odontología";
                case (int)AppointmentType.Pediatrics:
                    return "Pediatría";
                case (int)AppointmentType.Neurological:
                    return "Neurología";
                default:
                    return default;
            }
        }
    }
}
