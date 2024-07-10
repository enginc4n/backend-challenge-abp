using Abp.Application.Services;
using BackendChallenge.MultiTenancy.Dto;

namespace BackendChallenge.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

