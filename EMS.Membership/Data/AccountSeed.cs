using EMS.Data;
using EMS.Membership.Contexts;
using EMS.Membership.Entities;
using EMS.Membership.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Membership.Data
{
    public class AccountSeed : DataSeed
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        private readonly ApplicationUser _superAdminUser, _adminUser, _customerUser;
        private readonly Role _superAdminRole, _adminRole, _customerRole;

        public AccountSeed(UserManager userManager, RoleManager roleManager, ApplicationDbContext context)
            : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            _superAdminUser = new ApplicationUser("superadmin", "Nasir Uddin", "8801937845635", "nunnasir@gmail.com");
            _adminUser = new ApplicationUser("admin", "Talat Morshed", "8801817316436", "admin@gmail.com");
            _customerUser = new ApplicationUser("customer", "Demo Customer", "8801111111111", "democustomer@mail.com");

            _superAdminRole = new Role("SuperAdmin");
            _adminRole = new Role("Administrator");
            _customerRole = new Role("Customer");
        }

        private async Task<bool> CheckAndCreateRoleAsync(Role role)
        {
            if((await _roleManager.FindByNameAsync(role.Name)) == null)
            {
                var result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            return true;
        }

        private async Task SeedUserAsync()
        {
            IdentityResult result = null;
            if((await _userManager.FindByNameAsync(_superAdminUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_superAdminUser, "Dhaka#123");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_superAdminRole))
                    {
                        await _userManager.AddToRoleAsync(_superAdminUser, _superAdminRole.Name);
                    }
                }
            }

            if ((await _userManager.FindByNameAsync(_adminUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_adminUser, "Dhaka#123");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_adminRole))
                    {
                        await _userManager.AddToRoleAsync(_adminUser, _adminRole.Name);
                    }
                }
            }

            if ((await _userManager.FindByNameAsync(_customerUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_customerUser, "Dhaka#123");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_customerRole))
                    {
                        await _userManager.AddToRoleAsync(_customerUser, _customerRole.Name);
                    }
                }
            }
        }

        public override async Task SeedAsync()
        {
            await SeedUserAsync();
        }

    }
}
