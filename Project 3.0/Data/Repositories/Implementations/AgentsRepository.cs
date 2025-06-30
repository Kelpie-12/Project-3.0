
using System.Data.SqlClient;
using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class AgentsRepository : BaseRepository, IAgentsRepository
    {
        public AgentsRepository(IConfiguration configuration) : base(configuration)
        {
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
                                LastName = reader.GetString(2)
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
    }
}
