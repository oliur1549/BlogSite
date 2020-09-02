using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Membership.BusinessObjects
{
    public class ImageRequirement : IAuthorizationRequirement
    {
        public ImageRequirement()
        {
        }
    }
}
