namespace GAP.Business.Services
{
    using System.Collections.Generic;
    using GAP.Business.Interfaces;
    using GAP.Business.Messages;

    public class AppointmentTypeService : IListType<AppointmentTypeMessage>
    {
        public List<AppointmentTypeMessage> GetList()
        {
            List<AppointmentTypeMessage> listAppointmentTypeMessage = new List<AppointmentTypeMessage>();

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = 1,
                Name = "Medicina General"
            });

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = 2,
                Name = "Odontología"
            });

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = 3,
                Name = "Pediatría"
            });

            listAppointmentTypeMessage.Add(new AppointmentTypeMessage
            {
                Id = 4,
                Name = "Neurología"
            });

            // TODO: Sacar del config los valores.
            //System.Configuration.con ConfigurationManager


            return listAppointmentTypeMessage;
        }
    }
}
