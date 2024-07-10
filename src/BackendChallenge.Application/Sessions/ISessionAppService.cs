using System.Threading.Tasks;
using Abp.Application.Services;
using BackendChallenge.Sessions.Dto;

namespace BackendChallenge.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
