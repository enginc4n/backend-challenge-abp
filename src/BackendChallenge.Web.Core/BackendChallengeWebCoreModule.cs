using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Abp.Zero.Configuration;
using BackendChallenge.Authentication.JwtBearer;
using BackendChallenge.Configuration;
using BackendChallenge.EntityFrameworkCore;
using BackendChallenge.Movies.Jobs;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BackendChallenge
{
  [DependsOn(
    typeof(BackendChallengeApplicationModule),
    typeof(BackendChallengeEntityFrameworkModule),
    typeof(AbpAspNetCoreModule)
    , typeof(AbpAspNetCoreSignalRModule)
  )]
  public class BackendChallengeWebCoreModule : AbpModule
  {
    private readonly IWebHostEnvironment _env;
    private readonly IConfigurationRoot _appConfiguration;

    public BackendChallengeWebCoreModule(IWebHostEnvironment env)
    {
      _env = env;
      _appConfiguration = env.GetAppConfiguration();
    }

    public override void PreInitialize()
    {
      Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
        BackendChallengeConsts.ConnectionStringName
      );

      // Use database for language management
      Configuration.Modules.Zero()
        .LanguageManagement.EnableDbLocalization();

      Configuration.Modules.AbpAspNetCore()
        .CreateControllersForAppServices(
          typeof(BackendChallengeApplicationModule).GetAssembly()
        );

      ConfigureTokenAuth();
    }

    private void ConfigureTokenAuth()
    {
      IocManager.Register<TokenAuthConfiguration>();
      TokenAuthConfiguration tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

      tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
      tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
      tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
      tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
      tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
    }

    public override void Initialize()
    {
      IocManager.RegisterAssemblyByConvention(typeof(BackendChallengeWebCoreModule).GetAssembly());
    }

    public override void PostInitialize()
    {
      IocManager.Resolve<ApplicationPartManager>()
        .AddApplicationPartsIfNotAddedBefore(typeof(BackendChallengeWebCoreModule).Assembly);
      IocManager.Resolve<IBackgroundWorkerManager>()
        .Add(IocManager.Resolve<UpdateMovieDbWorker>());
    }
  }
}
