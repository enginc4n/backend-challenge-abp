using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BackendChallenge.Authorization;

namespace BackendChallenge;

[DependsOn(
  typeof(BackendChallengeCoreModule),
  typeof(AbpAutoMapperModule))]
public class BackendChallengeApplicationModule : AbpModule
{
  public override void PreInitialize()
  {
    Configuration.Authorization.Providers.Add<BackendChallengeAuthorizationProvider>();
    Configuration.BackgroundJobs.IsJobExecutionEnabled = true;
  }

  public override void Initialize()
  {
    Assembly thisAssembly = typeof(BackendChallengeApplicationModule).GetAssembly();

    IocManager.RegisterAssemblyByConvention(thisAssembly);

    Configuration.Modules.AbpAutoMapper()
      .Configurators.Add(
        // Scan the assembly for classes which inherit from AutoMapper.Profile
        cfg => cfg.AddMaps(thisAssembly)
      );
  }

  public override void PostInitialize()
  {
    // IBackgroundWorkerManager workerManager = IocManager.Resolve<IBackgroundWorkerManager>();
    // workerManager.Add(IocManager.Resolve<UpdateMovieDbWorker>());
  }
}
