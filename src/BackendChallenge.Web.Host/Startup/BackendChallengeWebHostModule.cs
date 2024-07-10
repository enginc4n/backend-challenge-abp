using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BackendChallenge.Configuration;

namespace BackendChallenge.Web.Host.Startup
{
  [DependsOn(
    typeof(BackendChallengeWebCoreModule))]
  public class BackendChallengeWebHostModule : AbpModule
  {
    private readonly IWebHostEnvironment _env;
    private readonly IConfigurationRoot _appConfiguration;

    public BackendChallengeWebHostModule(IWebHostEnvironment env)
    {
      _env = env;
      _appConfiguration = env.GetAppConfiguration();
    }

    public override void Initialize()
    {
      IocManager.RegisterAssemblyByConvention(typeof(BackendChallengeWebHostModule).GetAssembly());
    }
  }
}
