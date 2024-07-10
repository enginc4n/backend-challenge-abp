using System.Threading.Tasks;
using Abp.Application.Services;
using BackendChallenge.Authorization.Accounts.Dto;

namespace BackendChallenge.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
