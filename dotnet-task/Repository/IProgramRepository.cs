using dotnet_task.Domain.Models;

namespace dotnet_task.Repository
{
    public interface IProgramRepository
    {
        Task<InternshipProgram> CreateProgramAsync(InternshipProgram program);
        Task<InternshipProgram> GetProgramAsync(string id);
        Task<IEnumerable<InternshipProgram>> GetProgramsAsync();
        Task<InternshipProgram> UpdateProgramAsync(string id, InternshipProgram program);
    }
}