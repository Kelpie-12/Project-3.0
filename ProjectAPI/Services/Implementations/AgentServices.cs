
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ProjectAPI.Repositories;
using ProjectAPI.Model;
using ProjectAPI.Model.DTO;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Services.Implementations
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IPhotoServices _photoServices;
        private readonly JsonSerializerOptions options;

        public AgentServices(IAgentRepository agentRepository, IPhotoServices photoServices)
        {
            _agentRepository = agentRepository;
            _photoServices = photoServices;

            options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
        }

        public async Task<string> GetAgentPhotoByIdAsync(string id)
        {
            string photo = JsonSerializer.Serialize(await _photoServices.GetAgentPhotoByIdAsync(id), options);         
            return photo;
        }

        public async Task<string> GetAllAsync(bool archive = false)
        {
            List<AgentDTO> agents = new List<AgentDTO>();
            agents = await _agentRepository.GetAgents(archive);
            string json = JsonSerializer.Serialize(agents, options);
            return json;
        }

        public string GetAllAgentPhoto()
        {
            string json = JsonSerializer.Serialize(_photoServices.GetAllAgentPhoto(""), options);
            return json;
        }

        public async Task<string> GetByAgentIdAsync(int id)
        {
            AgentDTO agent = new AgentDTO();
            agent = await _agentRepository.GetAgentById(id);
            string json = JsonSerializer.Serialize(agent, options);
            return json;
        }

    }
}
