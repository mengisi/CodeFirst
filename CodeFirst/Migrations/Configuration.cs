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
                    new IdentityRole{Name="employee"},
                    new IdentityRole{Name="admin"},
                    new IdentityRole{Name="boss"}
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
                    UserName = "employee@Employee.com",
                    FirstName = "Robert",
                    LastName = "Lablanc",
                    Email = "employee1@employee.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher().HashPassword("123456"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
            context.Users.AddOrUpdate(user => user.Email, employee);  // 根据email来寻找user，这样做的话，email就不允许变化了
            context.SaveChanges();
            userManager.AddToRole(employee.Id, "employee");
            
            ApplicationUser Admin = new ApplicationUser
            {
                UserName = "admin@admin.com",
                FirstName = "Philippe",
                LastName = "Petellier",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher().HashPassword("123456"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            context.Users.AddOrUpdate(user => user.Email, Admin);
            context.SaveChanges();
            userManager.AddToRole(Admin.Id, "admin");
        }
    }
}
