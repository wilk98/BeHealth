using Microsoft.AspNetCore.Authorization;

namespace BeHealthBackend.Authorization;
public enum ResourceOperation
{
    Create,
    Read,
    Update,
    Delete
}
public class DoctorResourceOperationRequirement : IAuthorizationRequirement
{
    public ResourceOperation ResourceOperation { get; }
    public DoctorResourceOperationRequirement(ResourceOperation resourceOperation)
    {
        ResourceOperation = resourceOperation;
    }
}