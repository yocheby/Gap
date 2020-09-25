namespace GAP.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using GAP.Business.Messages;
    using GAP.Business.Services;
    
    public class PatientMessagesController : Controller
    {
        private PatientService _patientService = new PatientService();

        // GET: PatientMessages
        public ActionResult Index()
        {
            return View(_patientService.GetList());
        }

        // GET: PatientMessages/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientMessage patientMessage = _patientService.GetById(id.Value);
            if (patientMessage == null)
            {
                return HttpNotFound();
            }
            return View(patientMessage);
        }

        // GET: PatientMessages/Create
        public ActionResult Create()
        {
            IdentificationTypeService identificationTypeService = new IdentificationTypeService();
            ViewBag.IdentificationType = new SelectList(identificationTypeService.GetList(), "Id", "Name");
            return View();
        }

        // POST: PatientMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,IdentificationType,Identification,Email,Telephone")] PatientMessage patientMessage)
        {
            if (ModelState.IsValid)
            {                
                _patientService.Save(patientMessage);
                return RedirectToAction("Index");
            }

            return View(patientMessage);
        }

        // GET: PatientMessages/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PatientMessage patientMessage = _patientService.GetById(id.Value);

            IdentificationTypeService identificationTypeService = new IdentificationTypeService();
            ViewBag.IdentificationType = new SelectList(identificationTypeService.GetList(), "Id", "Name", patientMessage?.IdentificationType);

            if (patientMessage == null)
            {
                return HttpNotFound();
            }
            return View(patientMessage);
        }

        // POST: PatientMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,IdentificationType,Identification,Email,Telephone")] PatientMessage patientMessage)
        {
            if (ModelState.IsValid)
            {
                _patientService.Save(patientMessage);
                return RedirectToAction("Index");
            }
            return View(patientMessage);
        }

        // GET: PatientMessages/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientMessage patientMessage = _patientService.GetById(id.Value);
            if (patientMessage == null)
            {
                return HttpNotFound();
            }
            return View(patientMessage);
        }

        // POST: PatientMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _patientService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _patientService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
