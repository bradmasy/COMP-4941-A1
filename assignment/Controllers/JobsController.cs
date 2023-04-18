using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment.Models;

namespace assignment.Controllers
{
    public class JobsController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Customer).Include(j => j.Service);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? customerId, int? serviceId)
        {
            Console.WriteLine(customerId + " " + serviceId);
            if (customerId == null || serviceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.Jobs.FirstOrDefault(j => j.CustomerId == customerId && j.ServiceId == serviceId);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceID", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceId,CustomerId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.People, "Id", "Name", job.CustomerId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceID", "Name", job.ServiceId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? customerId, int? serviceId)
        {
            Console.WriteLine(customerId + " " + serviceId);
            if (customerId == null || serviceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.Jobs.FirstOrDefault(j => j.CustomerId == customerId && j.ServiceId == serviceId);

            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", job.CustomerId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceID", "Name", job.ServiceId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceId,CustomerId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.People, "Id", "Name", job.CustomerId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceID", "Name", job.ServiceId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? customerId, int? serviceId)
        {
            Console.WriteLine(customerId + " " + serviceId);
            if (customerId == null || serviceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.Jobs.FirstOrDefault(j => j.CustomerId == customerId && j.ServiceId == serviceId);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? customerId, int? serviceId)
        {
            var job = db.Jobs.FirstOrDefault(j => j.CustomerId == customerId && j.ServiceId == serviceId);
            db.Jobs.Remove(job);
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
