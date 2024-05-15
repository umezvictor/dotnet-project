using dotnet_task.Domain.Models;
using Newtonsoft.Json;

namespace dotnet_task.DTO
{
    public class CreateApplicationDto
    {
        public string ProgramTitle { get; set; }     
        public string Description { get; set; }
        public Dictionary<string, List<AnswerDto>> PersonalInformation { get; set; }
        public Dictionary<string, List<AnswerDto>> AdditionalQuestions { get; set; }
    }
}
