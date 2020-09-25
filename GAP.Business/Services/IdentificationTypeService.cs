namespace GAP.Business.Services
{
    using System.Collections.Generic;
    using GAP.Business.Global;
    using GAP.Business.Interfaces;
    using GAP.Business.Messages;

    public class IdentificationTypeService: IListType<IdentificationTypeMessage>
    {
        public List<IdentificationTypeMessage> GetList()
        {
            List<IdentificationTypeMessage> listIdentificationTypeMessage = new List<IdentificationTypeMessage>();

            listIdentificationTypeMessage.Add(new IdentificationTypeMessage {
                Id = (int)IdentificationType.NationalDocument,
                Name = "Cédula de Ciudadanía",
                Initials = "CC"                
            });

            listIdentificationTypeMessage.Add(new IdentificationTypeMessage
            {
                Id = (int)IdentificationType.Passport,
                Name = "Pasaporte",
                Initials = "Pass"
            });

            return listIdentificationTypeMessage;
        }
    }
}
