
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ProjectAPI.Repositories;
using ProjectAPI.Model;
using ProjectAPI.Model.DTO;

namespace ProjectAPI.Services.Implementations
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepository _agentRepository;
        private readonly JsonSerializerOptions options;

        public AgentServices(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
            options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
        }
        public async Task<string> GetAll(bool archive = false)
        {
            List<AgentDTO> agents = new List<AgentDTO>();
            agents = await _agentRepository.GetAgents(archive);
            string json = JsonSerializer.Serialize(agents, options);
            return json;
        }

        public async Task<string> GetByAgentId(int id)
        {
            AgentDTO agent = new AgentDTO();
            agent = await _agentRepository.GetAgentById(id);
            string json = JsonSerializer.Serialize(agent, options);
            return json;
        }
    }
}
