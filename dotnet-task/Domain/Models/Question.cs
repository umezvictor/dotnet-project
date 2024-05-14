using Newtonsoft.Json;

namespace dotnet_task.Domain.Models
{
    public class Question
    {
        public Question()
        {
            Id = Guid.NewGuid().ToString();
        }
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
