if (typeof (Appointment) === "undefined")
    Appointment = { __namespace: true };

Appointment.Function = {

    CallWebApi: async function (url, data) {

        const response = await fetch(url, {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer'
            ,
            body: JSON.stringify(data)
        });
        
        return response;
    },

    Call: function () {

        const PatientFilterMessage = {
            Names: $('#findbyname').val(),
            Identification: $('#findbyid').val()
        };

        Appointment.Function.CallWebApi('https://localhost:44389/api/AppointmentWebApi', PatientFilterMessage)
            .then(response => response.json())
            .then(function (data) {
                // Create and append the li's to the ul
                let patients = data;
                Appointment.Function.PatientToShow(patients);
            });
    },

    FindPatient: function () {
        Appointment.Function.Call();
    },

    PatientToShow: function (patient) {

        if (patient.length > 0) {

            $('#patientList tbody').empty();

            for (var i = 0; i < patient.length; i++) {

                const FirsName = `<td> ${patient[i].LastName} ${patient[i].FirstName} </td>`;
                const Identification = `<td> ${patient[i].Identification} </td>`;
                //const Button = '<td> <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="SelectPatient("' + patient[i].LastName + '","' + patient[i].Identification + '")>Seleccionar</button></td>';
                const Button = `<td> <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="Appointment.Function.SelectPatient('${patient[i].LastName} ${patient[i].FirstName}', '${patient[i].Id}')">Seleccionar</button></td>`;


                $('#patientList').append('<tbody><tr id=' + patient[i].Id + '>' + FirsName + Identification + Button + '</tr></tbody>');
            }
        }
    },

    SelectPatient: function (Name, id) {
        $('#IdPatient').val(id);
        $('#lableIdPatient').val(Name);
    }
}



