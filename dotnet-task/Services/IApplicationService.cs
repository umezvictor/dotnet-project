using dotnet_task.DTO;
using dotnet_task.Responses;

namespace dotnet_task.Services
{
    public interface IApplicationService
    {
        Task<Response<ApplicationDto>> CreateApplication(CreateApplicationDto applicationDto);
    }
}