using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeFirst.Models.ViewModels;

namespace CodeFirst.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var role = roleManager.FindByName("employee").Users.First();
            return View(db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList());
        }

        // GET: ApplicationUsers/Details/5
        [Authorize(Roles = "employee")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Adress,Email,PhoneNumber")] CreateEmployeeViewModel newEmployee)
        {
            ApplicationUser applicationUser = new ApplicationUser();

            if (ModelState.IsValid)
            {
                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

                applicationUser.FirstName = newEmployee.FirstName;
                applicationUser.LastName = newEmployee.LastName;
                applicationUser.Email = newEmployee.Email;
                applicationUser.Adress = newEmployee.Adress;
                applicationUser.PhoneNumber = newEmployee.PhoneNumber;
                applicationUser.UserName = newEmployee.Email; // 二者相同，因为登录时，自带的模板中有个方法FindAsync将email当作username
                applicationUser.PasswordHash = new PasswordHasher().HashPassword("123456");
                applicationUser.SecurityStamp = Guid.NewGuid().ToString();
                applicationUser.EmailConfirmed = true;
                db.Users.Add(applicationUser);
                db.SaveChanges();
                userManager.AddToRole(applicationUser.Id, "employee");
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        [Authorize(Roles = "employee")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "employee")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adress,PhoneNumber")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser userToUpdate = db.Users.Find(applicationUser.Id);
                if (applicationUser == null)
                {
                    return HttpNotFound();
                }
                userToUpdate.Adress = applicationUser.Adress;
                userToUpdate.PhoneNumber = applicationUser.PhoneNumber;

                db.Entry(userToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "ApplicationUsers", new {id = applicationUser.Id});
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            // First of all, delete the orders whick are created by this user
            db.Orders.RemoveRange(db.Orders.Where(o => o.ApplicationUser.Id == applicationUser.Id));

            db.Users.Remove(applicationUser);
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
