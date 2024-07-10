using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using BackendChallenge.Authorization.Roles;
using BackendChallenge.Authorization.Users;
using BackendChallenge.MultiTenancy;
using Microsoft.Extensions.Logging;
using Abp.Domain.Uow;

namespace BackendChallenge.Identity
{
  public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
  {
    public SecurityStampValidator(
      IOptions<SecurityStampValidatorOptions> options,
      SignInManager signInManager,
      ISystemClock systemClock,
      ILoggerFactory loggerFactory,
      IUnitOfWorkManager unitOfWorkManager)
      : base(options, signInManager, systemClock, loggerFactory, unitOfWorkManager)
    {
    }
  }
}
