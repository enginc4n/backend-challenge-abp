using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BackendChallenge.Configuration.Dto;

namespace BackendChallenge.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BackendChallengeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
