using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pre_SemesterAssignment_VMS.Models;

namespace Pre_SemesterAssignment_VMS.Controllers
{
    public class VolunteersController : Controller
    {
        private VMSContext db = new VMSContext();

        // GET: Volunteers
        public ActionResult Index()
        {
            var volunteers = db.Volunteers.Include(v => v.Education);
            return View(volunteers.ToList());
        }

        // GET: Volunteers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // GET: Volunteers/Create
        public ActionResult Create()
        {
            ViewBag.EducationId = new SelectList(db.Educations, "EducationId", "EducationLevel");
            return View();
        }

        // POST: Volunteers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolunteerId,FirstName,LastName,Username,Password,Address,PhoneNumber,EmailAddress,EmergencyContact,DriversLicenseOnFile,SSCardOnFile,EducationId")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EducationId = new SelectList(db.Educations, "EducationId", "EducationLevel", volunteer.Education.EducationId);
            return View(volunteer);
        }

        // GET: Volunteers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationId = new SelectList(db.Educations, "EducationId", "EducationLevel", volunteer.EducationId);
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolunteerId,FirstName,LastName,Username,Password,Address,PhoneNumber,EmailAddress,EmergencyContact,DriversLicenseOnFile,SSCardOnFile,EducationId")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EducationId = new SelectList(db.Educations, "EducationId", "EducationLevel", volunteer.EducationId);
            return View(volunteer);
        }

        // GET: Volunteers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
