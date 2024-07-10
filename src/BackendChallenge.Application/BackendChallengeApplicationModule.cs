using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BackendChallenge.Authorization;

namespace BackendChallenge
{
    [DependsOn(
        typeof(BackendChallengeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BackendChallengeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BackendChallengeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BackendChallengeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
