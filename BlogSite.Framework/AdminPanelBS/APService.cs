using Membership.Contexts;
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSite.Framework.AdminPanelBS
{
    public class APService : IAPService, IDisposable
    {
        private ApplicationDbContext context;
        public APService(ApplicationDbContext Context)
        {
            context = Context;
        }

        public void CreateAP(ApplicationUser applicationUser)
        {
            context.Add(applicationUser);
            context.SaveChanges();
        }

        public ApplicationUser DeleteUser(Guid id)
        {
            var user = context.Users.Find(id);
            context.Remove(user);
            context.SaveChanges();
            return user;
        }

        

        public void EditAP(ApplicationUser applicationUser)
        {
            var cus = context.Users.Find(applicationUser.Id);
            cus.Id = applicationUser.Id;
            cus.UserName = applicationUser.UserName;
            cus.FullName = applicationUser.FullName;
            cus.Email = applicationUser.Email;
            cus.PhoneNumber = applicationUser.PhoneNumber;
            cus.Status = applicationUser.Status;
            context.SaveChanges();
        }


        public (IList<ApplicationUser> records, int total, int totalDisplay) GetUser(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = context.Users.ToList();
            return (result, 0, 0);
        }
        public ApplicationUser GetUser(Guid id)
        {
            return context.Users.Find(id);
        }
        public void Dispose()
        {
            context?.Dispose();
        }
    }

}
