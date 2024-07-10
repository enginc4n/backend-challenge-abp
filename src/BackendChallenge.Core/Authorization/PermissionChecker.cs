using Abp.Authorization;
using BackendChallenge.Authorization.Roles;
using BackendChallenge.Authorization.Users;

namespace BackendChallenge.Authorization
{
  public class PermissionChecker : PermissionChecker<Role, User>
  {
    public PermissionChecker(UserManager userManager)
      : base(userManager)
    {
    }
  }
}
