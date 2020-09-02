using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Membership.BusinessObjects
{
    public class ImageRequirementHandler :
          AuthorizationHandler<ImageRequirement>
    {
        protected override Task HandleRequirementAsync(
               AuthorizationHandlerContext context,
               ImageRequirement requirement)
        {
            var claim = context.User.FindFirst("FullName");
            if (claim != null)
            {
                if(!string.IsNullOrWhiteSpace(claim.Value))
                    context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
