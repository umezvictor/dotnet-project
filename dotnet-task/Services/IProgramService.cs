using dotnet_task.DTO;
using dotnet_task.Responses;

namespace dotnet_task.Services
{
    public interface IProgramService
    {
        Task<Response<InternshipProgramDto>> CreateProgram(CreateProgramDto programDto);
        Task<Response<InternshipProgramDto>> GetProgram(string id);
        Task<Response<List<InternshipProgramDto>>> GetPrograms();
        Task<Response<string>> UpdateProgram(EditQuestionDto editQuestionDto);
    }
}