namespace CodeFirst.Migrations
{
    using CodeFirst.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirst.Models.ApplicationDbContext context)
        {
            // Add roles
            IdentityRole[] roles = new IdentityRole[] 
                {
                    new IdentityRole{Name="Employee"},
                    new IdentityRole{Name="Admin"},
                    new IdentityRole{Name="Boss"}
                };
            context.Roles.AddOrUpdate(role => role.Name, roles);
            context.SaveChanges();  // 先保存在数据库中，以便下面的代码能在数据库中找到相应的role
            
            // Prepare UserManager
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
      
            // Add users of different roles
            ApplicationUser employee = new ApplicationUser
                {
                    // In ASP.NET template, FindAsync() sets the USERNAME to the email 
                    // So here, UserName == Email
                    UserName = "Employee@Employee.com",
                    FirstName = "Robert",
                    LastName = "Lablanc",
                    Email = "Employee@Employee.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher().HashPassword("Employee"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
            context.Users.AddOrUpdate(user => user.Email, employee);  // 根据email来寻找user，这样做的话，email就不允许变化了
            context.SaveChanges();
            userManager.AddToRole(employee.Id, "Employee");
            
            ApplicationUser Admin = new ApplicationUser
            {
                UserName = "Admin@Admin.com",
                FirstName = "Philippe",
                LastName = "Petellier",
                Email = "Admin@Admin.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher().HashPassword("Admin"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            context.Users.AddOrUpdate(user => user.Email, Admin);
            context.SaveChanges();
            userManager.AddToRole(Admin.Id, "Admin");
        }
    }
}
