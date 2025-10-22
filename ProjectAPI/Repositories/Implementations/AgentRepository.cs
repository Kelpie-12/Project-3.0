using System.Data.SqlClient;
using System.Data.SqlTypes;
using ProjectAPI.Model.DTO;

namespace ProjectAPI.Repositories.Implementations
{
    public class AgentRepository : BaseRepository, IAgentRepository
    {
        public AgentRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public AgentDTO GetAgentById(int id)
        {
            AgentDTO agent = new AgentDTO();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_managerDTO_by_id";
                    cmd.Parameters.Add(new SqlParameter("@manId", id));
                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            agent = new AgentDTO()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Photo = reader.GetString(3) ?? "No photo"
                            };
                        }
                    }
                    else
                    {
                        agent.FirstName = agent.LastName = agent.Photo= "Not found";
                        agent.Id = -1;
                    }
                }
            }
            return agent;
        }
        public List<AgentDTO> GetAgents(bool archive)
        {
            List<AgentDTO> agents = new List<AgentDTO>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_all_managerDTO";
                    if (archive == true)
                        cmd.Parameters.Add(new SqlParameter("@archive", -1));
                    else
                        cmd.Parameters.Add(new SqlParameter("@archive", 1));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AgentDTO agent = new AgentDTO()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Photo = reader.GetString(3)
                            };
                            agents.Add(agent);
                        }
                    }
                }
            }
            return agents;
        }
    }
}
