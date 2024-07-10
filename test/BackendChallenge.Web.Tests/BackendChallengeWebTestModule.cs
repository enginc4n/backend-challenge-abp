using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BackendChallenge.EntityFrameworkCore;
using BackendChallenge.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BackendChallenge.Web.Tests
{
    [DependsOn(
        typeof(BackendChallengeWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BackendChallengeWebTestModule : AbpModule
    {
        public BackendChallengeWebTestModule(BackendChallengeEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackendChallengeWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BackendChallengeWebMvcModule).Assembly);
        }
    }
}