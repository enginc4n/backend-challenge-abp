using Abp.Application.Services.Dto;

namespace BackendChallenge.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

