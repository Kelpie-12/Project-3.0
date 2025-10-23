using System.Text.Json.Serialization;

namespace Project_3._0.Model.Domain
{
    public class AgentResponse
    {
        [JsonPropertyName("agent")]
        public IList<Agent> Agent { get; set; }
    }
}
