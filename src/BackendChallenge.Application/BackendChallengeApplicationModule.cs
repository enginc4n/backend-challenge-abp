using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using BackendChallenge.Authorization;
using BackendChallenge.Movies.Jobs;

namespace BackendChallenge;

[DependsOn(
  typeof(BackendChallengeCoreModule),
  typeof(AbpAutoMapperModule))]
public class BackendChallengeApplicationModule : AbpModule
{
  public override void PreInitialize()
  {
    Configuration.Authorization.Providers.Add<BackendChallengeAuthorizationProvider>();

    IBackgroundWorkerManager workerManager = IocManager.Resolve<IBackgroundWorkerManager>();
    workerManager.Add(IocManager.Resolve<UpdateMovieDbWorker>());
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
}
