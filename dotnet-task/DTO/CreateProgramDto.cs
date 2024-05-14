using dotnet_task.Domain.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace dotnet_task.DTO
{
    public class CreateProgramDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Dictionary<string, List<Question>> PersonalInformation { get; set; }

        [Required]
        public Dictionary<string, List<Question>> AdditionalQuestions { get; set; }
    }
}
