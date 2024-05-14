using dotnet_task.Domain.Models;
using Newtonsoft.Json;

namespace dotnet_task.DTO
{
    public class InternshipProgramDto
    {      
        public string Id { get; set; }      
        public string Title { get; set; }      
        public string Description { get; set; }      
        public Dictionary<string, List<Question>> PersonalInformation { get; set; }      
        public Dictionary<string, List<Question>> AdditionalQuestions { get; set; }
    }
}
