
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
                    cmd.CommandText = $"get_objects_apartments_all_by_view";
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
                                Id = reader.GetInt32(0),
                                AgentId= reader.GetInt32(1),
                                TypeObject=reader.GetString(2),
                                TypeOffer=reader.GetString(3),
                                Citi =reader.GetString(4),
                                Street=reader.GetString(5),
                                House=reader.GetInt32(6),
                                NumberApartment=reader.GetInt32(7),
                                Floor=reader.GetInt32(8),
                                AreaHouse=reader.GetInt32(9),
                                Rooms=reader.GetInt32(10),
                                Price=reader.GetDecimal(11),
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
            Apartment apartment = new Apartment();
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

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           

                            apartment = new Apartment()
                            {
                                //  Id = reader.GetInt32(0)         ,
                                //  Citi = reader.GetString(3)            ,
                                //  Street = reader.GetString(4)          ,
                                //  House = reader.GetInt32(5)            ,
                                //  Price = reader.GetDecimal(6)          ,
                                //Desc = "",// reader.GetString(7)        , ;
                                //  NumberApartment = reader.GetInt32(8)  ,
                                //  Floor = reader.GetInt32(9)            ,
                                //  AreaHouse = reader.GetInt32(10)       ,
                                //Rooms = reader.GetInt32(11)
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
                                Desc = ""
                            };                            
                        }
                    }
                }
            }



            return apartment;
        }
    }
}
