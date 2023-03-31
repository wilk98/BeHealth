﻿using System.Security.Claims;
using core;
using Microsoft.AspNetCore.Authorization;

namespace BeHealthBackend.Authorization;
public class DoctorResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Doctor>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement,
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