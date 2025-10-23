using System.Data.SqlClient;
using ProjectAPI.Model;
using ProjectAPI.Model.DTO;

namespace ProjectAPI.Repositories.Implementations
{
    public class ApartmentRepository : BaseRepository, IApartmentRepository
    {
        public ApartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }           

        public async Task<List<ApartmentDTO>> GetAll(bool brandNew)
        {
            List<ApartmentDTO> apartments = new List<ApartmentDTO>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_objects_apartments_all_by_view";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));
                    cmd.Parameters.Add(new SqlParameter("@offer", 1));
                    cmd.Parameters.Add(new SqlParameter("@new", brandNew));

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ApartmentDTO apartment = new ApartmentDTO()
                            {
                                Id = reader.GetInt32(0),
                                AgentId = reader.GetInt32(1),
                                TypeObject = reader.GetString(2),
                                TypeOffer = reader.GetString(3),
                                Citi = reader.GetString(4),
                                Street = reader.GetString(5),
                                House = reader.GetInt32(6),
                                NumberApartment = reader.GetInt32(7),
                                Floor = reader.GetInt32(8),
                                AreaHouse = reader.GetInt32(9),
                                Rooms = reader.GetInt32(10),
                                Price = reader.GetDecimal(11),
                                PathPhoto = reader.GetString(12),                              
                                Description = new Description()
                                {
                                    Title = reader.GetString(13),
                                    Paragraph_1 = reader.GetString(14),
                                    Paragraph_2 = reader.GetString(15),
                                    Paragraph_3 = reader.GetString(16)
                                }
                            };
                           // apartment.Photo = new List<Photo>();
                            apartments.Add(apartment);
                        }
                    }
                    reader.Close();
                }            
            }
            return apartments;
        }

        public async Task<ApartmentDTO?> GetById(int id)
        {
            ApartmentDTO apartment = new ApartmentDTO();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_objects_apartments_by_id_by_view";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            apartment = new ApartmentDTO()
                            {
                                Id = reader.GetInt32(0),
                                AgentId = reader.GetInt32(1),
                                TypeObject = reader.GetString(2),
                                TypeOffer = reader.GetString(3),
                                Citi = reader.GetString(4),
                                Street = reader.GetString(5),
                                House = reader.GetInt32(6),
                                NumberApartment = reader.GetInt32(7),
                                Floor = reader.GetInt32(8),
                                AreaHouse = reader.GetInt32(9),
                                Rooms = reader.GetInt32(10),
                                Price = reader.GetDecimal(11),                              
                                Description = new Description()
                                {
                                    Title = reader.GetString(12),
                                    Paragraph_1 = reader.GetString(13),
                                    Paragraph_2 = reader.GetString(14),
                                    Paragraph_3 = reader.GetString(15)
                                },
                                PathPhoto = reader.GetString(16)
                            };
                        }
                    }
                    reader.Close();

                }        
            }
            return apartment;
        }

        public async Task<List<ApartmentDTO>> GetTop()
        {
            List<ApartmentDTO> apartments = new List<ApartmentDTO>();
            ApartmentDTO apartment = new ApartmentDTO();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_objects_apartments_top_by_view";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));
                    cmd.Parameters.Add(new SqlParameter("@offer", 1));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader =await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            apartment = new ApartmentDTO()
                            {
                                Id = reader.GetInt32(0),
                                Citi = reader.GetString(1),
                                Street = reader.GetString(2),
                                House = reader.GetInt32(3),
                                Price = reader.GetDecimal(4),
                                PathPhoto = reader.GetString(5)
                                //Description = new Description()
                                //{
                                //    Title = reader.GetString(12),
                                //    Paragraph_1 = reader.GetString(13),
                                //    Paragraph_2 = reader.GetString(14),
                                //    Paragraph_3 = reader.GetString(15)
                                //}

                            };
                            //apartment.Photo = new List<Photo>();
                            apartments.Add(apartment);
                        }
                    }
                    reader.Close();
                }             
            }

            return apartments;
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
