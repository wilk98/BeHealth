using System.Security.Claims;
using BeHealthBackend.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BeHealthBackend.Authorization;
public class DoctorResourceOperationRequirementHandler : AuthorizationHandler<DoctorResourceOperationRequirement, Doctor>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DoctorResourceOperationRequirement requirement,
        Doctor doctor)
    {
        if (requirement.ResourceOperation is ResourceOperation.Read or ResourceOperation.Create)
        {
            context.Succeed(requirement);
        }

        var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
        if (doctor.Id == int.Parse(userId))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}