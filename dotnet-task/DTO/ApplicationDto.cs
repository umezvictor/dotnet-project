using dotnet_task.Domain.Models;
using Newtonsoft.Json;

namespace dotnet_task.DTO
{
    public class ApplicationDto
    {      
        public string Id { get; set; }     
        public string ProgramTitle { get; set; }     
        public string Description { get; set; }
        public Dictionary<string, List<Answer>> PersonalInformation { get; set; }       
        public Dictionary<string, List<Answer>> AdditionalQuestions { get; set; }
    }
}
