using Microsoft.AspNetCore.Identity;

namespace DisasterResponseHub.Infrastructure
{
    public class CustomUserValidator : UserValidator<IdentityUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> lstIdentityErrors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (!user.Email.EndsWith("@DisasterRepsonseHub.com"))
            {
                lstIdentityErrors.Add(new IdentityError()
                {
                    Code = "OutOfDomain",
                    Description = "Email must end with @DisasterRepsonseHub.com"
                });
            }

            return lstIdentityErrors.Count == 0 ? IdentityResult.Success 
                : IdentityResult.Failed(lstIdentityErrors.ToArray());
        }
    }
}
