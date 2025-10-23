
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class AgentsRepository : BaseRepository, IAgentsRepository
    {
        
       
        public AgentsRepository(IConfiguration configuration) : base(configuration)
        {
        }
        static HttpClient client = new HttpClient();
        static async Task<Agent> GetAgentById2(int id)
        {
            Agent agent = null;
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5190/api/Agent/GetAgentById/{id}");
            if (response.IsSuccessStatusCode)
            {
              string _agent = await response.Content.ReadAsStringAsync();
                agent.FirstName = _agent;
            }

            return agent;
        }

        public Agent GetAgentById(int id)
        {
            Agent agent = new Agent();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_manager_by_id";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));
                    cmd.Parameters.Add(new SqlParameter("@manId", id));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            agent = new Agent()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Photo = reader.GetString(3) ?? ""
                            };
                        }
                    }
                }
            }
            return agent;

        }

        public List<Agent> GetAgents()
        {
            List<Agent> agents = new List<Agent>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_all_manager";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Agent agent = new Agent()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Photo=reader.GetString(3)??""
                            };
                            agents.Add(agent);
                        }
                    }
                }
            }
            return agents;
        }

              //async Task<Agent> GetAgentByIdAsync(string path)
        //{
        //    client.BaseAddress = new Uri(CreateAPIConnection());
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        Agent agent = new Agent();
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        agent = await response.Content.ReadFromJsonAsync<Agent>();

        //    }
        //    return agent;
        //}


    }
}
