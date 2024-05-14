using dotnet_task.Domain.Models;

namespace dotnet_task.DTO
{
    public class CreateApplicationDto
    {      
        public string ProgramId { get; set; }
        public Dictionary<string, List<Answer>> PersonalInformation { get; set; }
        public Dictionary<string, List<Answer>> AdditionalQuestions { get; set; }
    }
}
