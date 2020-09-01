using System;

using Microsoft.AspNetCore.Identity;

namespace EMS.Membership.Entities
{
    public class UserLogin
        : IdentityUserLogin<Guid>
    {
        public UserLogin()
            : base()
        {

        }
    }
}
