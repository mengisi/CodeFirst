using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models;
using CodeFirst.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeFirst.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            IEnumerable<OrderWithUserViewModel> allOrders  = (from order in db.Orders
                         join user in db.Users
                         on order.ApplicationUser.Id equals user.Id
                         select new OrderWithUserViewModel()
                         {
                             Id = order.Id,
                             UserId = user.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Email = user.Email,
                             SubmitTime = order.SubmitTime,
                             ApproveTime = order.ApproveTime,
                             IsApproved = order.IsApproved,
                             ProductName = order.ProductName,
                             Quantity = order.Quantity,
                             Price = order.Price,
                             Total = order.Total,
                         }).ToList();

            return View(allOrders);

        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Order order = db.Orders.Find(id);
            //  if (order == null)
            // {
            //      return HttpNotFound();
            //  }
            // return View(order);
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,ProductName,Quantity,Price,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
                order.ApplicationUser = userManager.FindById(User.Identity.GetUserId());

                order.SubmitTime = DateTime.Now;
                 db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //   Order order = db.Orders.Find(id);
            //  if (order == null)
            //  {
            //       return HttpNotFound();
            //   }
            return View();
            // return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubmitTime,ApproveTime,Description,IsApproved,ItemName,Quantity,Price,Total,ApplicationUserId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Order order = db.Orders.Find(id);
            //  if (order == null)
            //   {
            //       return HttpNotFound();
            //   }
            return View();
            // return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //  Order order = db.Orders.Find(id);
            //  db.Orders.Remove(order);
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
