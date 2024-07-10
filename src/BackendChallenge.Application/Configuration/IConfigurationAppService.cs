using System.Threading.Tasks;
using BackendChallenge.Configuration.Dto;

namespace BackendChallenge.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
