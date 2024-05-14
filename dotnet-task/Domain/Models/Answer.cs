using Newtonsoft.Json;

namespace dotnet_task.Domain.Models
{
    public class Answer
    {
       
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("response")]
        public string Response { get; set; }
    }
}
