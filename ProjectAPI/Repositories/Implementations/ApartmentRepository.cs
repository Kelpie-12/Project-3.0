using System.Data.SqlClient;
using ProjectAPI.Model.DTO;

namespace ProjectAPI.Repositories.Implementations
{
    public class ApartmentRepository : BaseRepository, IApartmentRepository
    {
        public ApartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public int SetNewApartment(FileUploadRequestDTO aprt)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "create_new_object_apartment";
                    cmd.Parameters.AddWithValue("@manager_lastname", "Мордовин");
                    cmd.Parameters.AddWithValue("@type_object", 0);
                    cmd.Parameters.AddWithValue("@type_offer", 1);
                    cmd.Parameters.AddWithValue("@client_id", 1);
                    cmd.Parameters.AddWithValue("@citi", aprt.Citi);
                    cmd.Parameters.AddWithValue("@street", aprt.Street);
                    cmd.Parameters.AddWithValue("@home", aprt.House);
                    cmd.Parameters.AddWithValue("@apart", aprt.NumberApartment);
                    cmd.Parameters.AddWithValue("@floor", aprt.Floor);
                    cmd.Parameters.AddWithValue("@areaHouse", aprt.AreaHouse);
                    cmd.Parameters.AddWithValue("@rooms", aprt.Rooms);
                    cmd.Parameters.AddWithValue("@price", aprt.Price);
                    cmd.Parameters.AddWithValue("@brandNew", aprt.BrandNew);
                    cmd.Parameters.AddWithValue("@title", aprt.Description.Title);
                    cmd.Parameters.AddWithValue("@p_1", aprt.Description.Paragraph_1);
                    cmd.Parameters.AddWithValue("@p_2", aprt.Description.Paragraph_2);
                    cmd.Parameters.AddWithValue("@p_3", aprt.Description.Paragraph_3);

                    cmd.Parameters.Add("@photo_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int id = Convert.ToInt32(cmd.Parameters["@photo_id"].Value);
                    conn.Close();
                    return id;

                }
            }
        }
    }
}
