using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    { 
        private readonly UserManager<IdentityUser> _userManager;            
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly BookShopDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            BookShopDbContext db)
        {
            _userManager = userManager;            
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            //apply migrations if they are not applied
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp)).GetAwaiter().GetResult();

                //create admin user
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@init.com",
                    Email = "admin@init.com",
                    Name = "admin",
                    PhoneNumber = "111222333",
                    StreetAddress = "test 123 Ave",
                    State = "State Name",
                    City = "City Name",
                    PostalCode = "111222333"
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@init.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
