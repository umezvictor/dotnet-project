using Newtonsoft.Json;

namespace dotnet_task.Domain.Models
{
    public class InternshipProgram
    {
        public InternshipProgram()
        {
            Id = Guid.NewGuid().ToString();
            PersonalInformation = new Dictionary<string, List<Question>>();
            AdditionalQuestions = new Dictionary<string, List<Question>>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("personalInformation")]
        public Dictionary<string, List<Question>> PersonalInformation { get; set; }

        [JsonProperty("additionalQuestions")]
        public Dictionary<string, List<Question>> AdditionalQuestions { get; set; }
    }
}
