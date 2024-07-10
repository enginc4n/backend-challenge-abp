using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using BackendChallenge.Authorization.Roles;
using BackendChallenge.Authorization.Users;
using BackendChallenge.Configuration;
using BackendChallenge.Localization;
using BackendChallenge.MultiTenancy;
using BackendChallenge.Timing;

namespace BackendChallenge;

[DependsOn(typeof(AbpZeroCoreModule))]
public class BackendChallengeCoreModule : AbpModule
{
  public override void PreInitialize()
  {
    Configuration.Auditing.IsEnabledForAnonymousUsers = true;

    // Declare entity types
    Configuration.Modules.Zero()
      .EntityTypes.Tenant = typeof(Tenant);
    Configuration.Modules.Zero()
      .EntityTypes.Role = typeof(Role);
    Configuration.Modules.Zero()
      .EntityTypes.User = typeof(User);

    BackendChallengeLocalizationConfigurer.Configure(Configuration.Localization);

    // Enable this line to create a multi-tenant application.
    Configuration.MultiTenancy.IsEnabled = BackendChallengeConsts.MultiTenancyEnabled;

    // Configure roles
    AppRoleConfig.Configure(Configuration.Modules.Zero()
      .RoleManagement);

    Configuration.Settings.Providers.Add<AppSettingProvider>();

    Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));

    Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = BackendChallengeConsts.DefaultPassPhrase;
    SimpleStringCipher.DefaultPassPhrase = BackendChallengeConsts.DefaultPassPhrase;
  }

  public override void Initialize()
  {
    IocManager.RegisterAssemblyByConvention(typeof(BackendChallengeCoreModule).GetAssembly());
  }

  public override void PostInitialize()
  {
    IocManager.Resolve<AppTimes>()
      .StartupTime = Clock.Now;
  }
}
