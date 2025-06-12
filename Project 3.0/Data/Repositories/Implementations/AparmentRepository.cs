
using System;
using System.Data.SqlClient;
using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class AparmentRepository : BaseRepository, IApartmentRepository
    {
        public AparmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Apartment> GetAll()
        {
            List<Apartment> apartments = new List<Apartment>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_objects_apartments_all";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));
                    cmd.Parameters.Add(new SqlParameter("@offer", 1));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Apartment apartment = new Apartment()
                            {
                                ObjectId = reader.GetInt32(0),
                                Citi=reader.GetString(2),
                                Street=reader.GetString(3),
                                House=reader.GetInt32(4),
                                NumberApartment=reader.GetInt32(5),
                                Floor=reader.GetInt32(6),
                                AreaHouse=reader.GetInt32(7),
                                Rooms=reader.GetInt32(8),
                                Price=reader.GetDecimal(9),
                                Desc=""
                            };
                            apartments.Add(apartment);
                        }
                    }
                }
            }

            return apartments;
        }

        public Apartment? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
