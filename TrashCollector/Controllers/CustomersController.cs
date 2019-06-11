using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db;

        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street");
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            customer.Address = new Address();
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,AddressId,Address,WeeklyPickUp,OneTimePickUp,SuspendPickUpStart,SuspendPickUpEnd")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                // ALSO ADD THE NEW ADDRESS! :)
                var currentUserId = User.Identity.GetUserId();
                db.Addresses.Add(customer.Address);
                db.SaveChanges();
                customer.AddressId = customer.Address.Id;
                customer.ApplicationId = currentUserId;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            customer.Address = db.Addresses.Where(s => s.Id == customer.AddressId).SingleOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,AddressId,Address,WeeklyPickUp,ConfirmPickup,OneTimePickUp,SuspendPickUpStart,SuspendPickUpEnd")] Customer customer)
        {
            if (ModelState.IsValid)
            {               
                db.Entry(customer).State = EntityState.Modified;
                db.Entry(customer.Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            Address addressToDelete = db.Addresses.Where(a => a.Id == customer.AddressId).FirstOrDefault();
            db.Customers.Remove(customer);
            db.Addresses.Remove(addressToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customers/Edit/5
        public ActionResult SpecialPickups(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            customer.Address = db.Addresses.Where(s => s.Id == customer.AddressId).SingleOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SpecialPickups([Bind(Include = "Id,ApplicationId,ApplicationUser,FirstName,LastName,AddressId,Address,ConfirmPickup,WeeklyPickUp,OneTimePickUp,SuspendPickUpStart,SuspendPickUpEnd")] Customer customer)
        {
            customer.ApplicationId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.Entry(customer.Address).State = EntityState.Modified;              
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult ConfirmPickup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            customer.Address = db.Addresses.Where(s => s.Id == customer.AddressId).SingleOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmPickup([Bind(Include = "Id,ApplicationId,ApplicationUser,FirstName,LastName,AddressId,Address,ConfirmPickup,WeeklyPickUp,OneTimePickUp,SuspendPickUpStart,SuspendPickUpEnd")] Customer customer)
        {
            customer.ApplicationId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.Entry(customer.Address).State = EntityState.Modified;
                db.Entry(customer.ConfirmPickup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
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
