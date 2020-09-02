using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Membership.BusinessObjects
{
    public class AgeRequirementHandler :
          AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(
               AuthorizationHandlerContext context,
               AgeRequirement requirement)
        {
            var claim = context.User.FindFirst("Age");
            if (claim != null)
            {
                if(int.Parse(claim.Value) >= 18)
                    context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
