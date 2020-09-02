using System;

using Microsoft.AspNetCore.Identity;

namespace EMS.Membership.Entities
{
    public class UserToken
        : IdentityUserToken<Guid>
    {
        public UserToken()
            : base()
        {

        }
    }
}
