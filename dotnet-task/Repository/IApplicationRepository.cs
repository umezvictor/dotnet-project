using dotnet_task.Domain.Models;

namespace dotnet_task.Repository
{
    public interface IApplicationRepository
    {
        Task<Applications> CreateApplicationAsync(Applications application);
    }
}