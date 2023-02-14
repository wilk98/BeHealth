using System.Security.Claims;
using BeHealthBackend.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BeHealthBackend.Authorization;
public class PatientResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Patient>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement,
        Patient patient)
    {
        if (requirement.ResourceOperation is ResourceOperation.Read or ResourceOperation.Create)
        {
            context.Succeed(requirement);
        }

        var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
        if (patient.Id == int.Parse(userId))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}