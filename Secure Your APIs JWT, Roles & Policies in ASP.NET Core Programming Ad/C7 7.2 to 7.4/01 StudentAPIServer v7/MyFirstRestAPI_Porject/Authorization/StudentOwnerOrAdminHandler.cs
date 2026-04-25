using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// This authorization handler enforces the ownership rule for student resources.
// It checks whether the current user is either:
// - An Admin (full access), OR
// - The owner of the student record being requested
public class StudentOwnerOrAdminHandler
    : AuthorizationHandler<StudentOwnerOrAdminRequirement, int>
{
    //context is user, requirement is the requirement we want to check, studentId is the resource being accessed
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        StudentOwnerOrAdminRequirement requirement,
        int studentId)
    {
        // Admin override
        if (context.User.IsInRole("Admin"))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        // Ownership check
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (int.TryParse(userId, out int authenticatedStudentId) &&
            authenticatedStudentId == studentId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;// return false if the requirement is not met, but we don't need to explicitly call context.Fail() here
    }
}
