using dotnet_task.Domain.Models;
using Newtonsoft.Json;

namespace dotnet_task.DTO
{
    public class ApplicationDto
    {      
        public string Id { get; set; }
        public string ProgramId { get; set; }
        public Dictionary<string, List<Answer>> PersonalInformation { get; set; }       
        public Dictionary<string, List<Answer>> AdditionalQuestions { get; set; }
    }
}
