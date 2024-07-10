using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BackendChallenge.Controllers
{
    public abstract class BackendChallengeControllerBase: AbpController
    {
        protected BackendChallengeControllerBase()
        {
            LocalizationSourceName = BackendChallengeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
