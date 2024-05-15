using Newtonsoft.Json;

namespace dotnet_task.Domain.Models
{
    public class Applications
    {
        public Applications()
        {
             Id = Guid.NewGuid().ToString();
        }
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("programTitle")]
        public string ProgramTitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("personalInformation")]
        public Dictionary<string, List<Answer>> PersonalInformation { get; set; }

        [JsonProperty("additionalQuestions")]
        public Dictionary<string, List<Answer>> AdditionalQuestions { get; set; }
    }
}
