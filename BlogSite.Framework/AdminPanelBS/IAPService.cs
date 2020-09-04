using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.AdminPanelBS
{
    public interface IAPService : IDisposable
    {
        (IList<ApplicationUser> records, int total, int totalDisplay) GetUser(int pageIndex,
                                                                    int pageSize,
                                                                    string searchText,
                                                                    string sortText);
        void CreateAP(ApplicationUser applicationUser);
        void EditAP(ApplicationUser applicationUser);
        ApplicationUser GetUser(Guid id);
        ApplicationUser DeleteUser(Guid id);
    }
}
