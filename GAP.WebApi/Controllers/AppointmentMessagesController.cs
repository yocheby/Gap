namespace GAP.WebApi.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using GAP.Business.Messages;
    using GAP.Business.Services;

    public class AppointmentMessagesController : Controller
    {
        private AppointmentService _appointmentService = new AppointmentService();

        // GET: AppointmentMessages
        public ActionResult Index()
        {
            return View(_appointmentService.GetList());
        }

        // GET: AppointmentMessages/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentMessage appointmentMessage = _appointmentService.GetById(id.Value);
            if (appointmentMessage == null)
            {
                return HttpNotFound();
            }
            return View(appointmentMessage);
        }

        // GET: AppointmentMessages/Create
        public ActionResult Create()
        {
            PatientService patientService = new PatientService();
            ViewBag.IdPatient = new SelectList(patientService.GetList(), "Id", "FirstName");

            //AppointmentTypeService appointmentTypeService = new AppointmentTypeService();
            ViewBag.IdAppointmentType = new SelectList(AppointmentTypeService.GetList(), "Id", "Name");

            return View();
        }

        // POST: AppointmentMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPatient,IdAppointmentType,Date,State")] AppointmentMessage appointmentMessage)
        {
            if (ModelState.IsValid)
            {
                AppointmentDuplicatesService appointmentDuplicatesService = new AppointmentDuplicatesService();
                appointmentDuplicatesService.AppointmentDate = appointmentMessage.Date;
                appointmentDuplicatesService.IdPatient = appointmentMessage.IdPatient;
                appointmentDuplicatesService.IdAppointment = appointmentMessage.Id;

                if (!appointmentDuplicatesService.Exist())
                {
                    _appointmentService.Save(appointmentMessage);
                    return RedirectToAction("Index");
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Ya existe una cita para la fecha seleccionada.");
            }

            return View(appointmentMessage);
        }

        // GET: AppointmentMessages/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AppointmentMessage appointmentMessage = _appointmentService.GetById(id.Value);

            PatientService patientService = new PatientService();
            ViewBag.IdPatient = new SelectList(patientService.GetList(), "Id", "FirstName", appointmentMessage?.IdPatient);

            ViewBag.IdAppointmentType = new SelectList(AppointmentTypeService.GetList(), "Id", "Name", appointmentMessage?.IdAppointmentType);

            if (appointmentMessage == null)
            {
                return HttpNotFound();
            }
            return View(appointmentMessage);
        }

        // POST: AppointmentMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPatient,IdAppointmentType,Date,State")] AppointmentMessage appointmentMessage)
        {
            if (ModelState.IsValid)
            {
                AppointmentDuplicatesService appointmentDuplicatesService = new AppointmentDuplicatesService();
                appointmentDuplicatesService.AppointmentDate = appointmentMessage.Date;
                appointmentDuplicatesService.IdPatient = appointmentMessage.IdPatient;
                appointmentDuplicatesService.IdAppointment = appointmentMessage.Id;

                if (!appointmentDuplicatesService.Exist())
                {
                    _appointmentService.Save(appointmentMessage);
                    return RedirectToAction("Index");
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Ya existe una cita para la fecha seleccionada.");
            }
            return View(appointmentMessage);
        }

        // GET: AppointmentMessages/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentMessage appointmentMessage = _appointmentService.GetById(id.Value);
            if (appointmentMessage == null)
            {
                return HttpNotFound();
            }
            return View(appointmentMessage);
        }

        // POST: AppointmentMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _appointmentService.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: AppointmentMessages/Cancel/5
        public ActionResult Cancel(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentMessage appointmentMessage = _appointmentService.GetById(id.Value);
            if (appointmentMessage == null)
            {
                return HttpNotFound();
            }
            return View(appointmentMessage);
        }

        // POST: AppointmentMessages/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelConfirmed(Guid id)
        {
            CancelerService cancelerService = new CancelerService();
            if (cancelerService.Cancel(id, DateTime.Now))
                return RedirectToAction("Index");
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Las citas se deben cancelar 24 horas antes.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appointmentService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
