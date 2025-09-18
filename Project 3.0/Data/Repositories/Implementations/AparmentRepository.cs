
using System;
using System.Data.SqlClient;
using System.Globalization;
using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class AparmentRepository : BaseRepository, IApartmentRepository
    {
        public AparmentRepository(IConfiguration configuration) : base(configuration)
        {
        }
        private List<Photo> GetPhotos(string directoryPath)
        {
            List<Photo> tmp = new List<Photo>();
            var dir = Directory.GetCurrentDirectory();
            dir += "\\wwwroot" + directoryPath;
           //dir = dir.Substring(0, dir.Length - 10);
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            foreach (var file in directoryInfo.GetFiles()) //проходим по файлам
            {                
               // if (Path.GetExtension(file.FullName) == "jpg" || Path.GetExtension(file.FullName) == "png"|| Path.GetExtension(file.FullName) == "jpeg")
               // {                  
                    tmp.Add(new Photo() { Id = 0, ObjectId = 0, Path = directoryPath+"\\"+ file.Name });
               // }
            }

            return tmp;
        }

        public List<Apartment> GetAll(bool brandNew)
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
                    cmd.Parameters.Add(new SqlParameter("@new", brandNew));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Apartment apartment = new Apartment()
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
                                PathPhoto= reader.GetString(12),
                                //BrandNew= reader.GetBoolean(12),
                                Desc = "",
                                //Description = new Description()
                                //{
                                //    Title = reader.GetString(12),
                                //    Paragraph_1 = reader.GetString(13),
                                //    Paragraph_2 = reader.GetString(14),
                                //    Paragraph_3 = reader.GetString(15)
                                //}
                            };
                            apartment.Photo = new List<Photo>();
                            apartments.Add(apartment);
                        }
                    }
                    reader.Close();

                }
                for (int i = 0; i < apartments.Count; i++)
                {
                    apartments[i].Photo = GetPhotos(apartments[i].PathPhoto);
                }
                //for (int i = 0; i < apartments.Count; i++)
                //{
                //    using (SqlCommand cmd = con.CreateCommand())
                //    {

                //        cmd.Connection = con;
                //        //cmd.CommandType = System.Data.CommandType.Text;
                //        cmd.CommandType = System.Data.CommandType.Text;
                //        cmd.CommandText = $"SELECT top(1) [Photo] FROM [Photo] where ObjectId=@id ";
                //        cmd.Parameters.Add(new SqlParameter("@id", apartments[i].Id));
                //        SqlDataReader reader = cmd.ExecuteReader();
                //        if (reader.HasRows)
                //        {
                //            while (reader.Read())
                //            {
                //                apartments[i].Photo.Add(new Photo() { Path = reader.GetString(0) });
                //            }
                //        }
                //        reader.Close();
                //    }
                //}
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
                                Desc = "",
                                Description = new Description()
                                {
                                    Title = reader.GetString(12),
                                    Paragraph_1 = reader.GetString(13),
                                    Paragraph_2 = reader.GetString(14),
                                    Paragraph_3 = reader.GetString(15)
                                },
                                PathPhoto=reader.GetString(16)
                                
                            };
                        }
                    }
                    reader.Close();

                }
                apartment.Photo = GetPhotos(apartment.PathPhoto);
              
                //using (SqlCommand cmd = con.CreateCommand())
                //{
                //    cmd.Connection = con;
                //    //cmd.CommandType = System.Data.CommandType.Text;
                //    cmd.CommandType = System.Data.CommandType.Text;
                //    cmd.CommandText = $"SELECT [Photo] FROM [Photo] where ObjectId=@id ";
                //    cmd.Parameters.Add(new SqlParameter("@id", id));
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    if (reader.HasRows)
                //    {
                //        while (reader.Read())
                //        {
                //            apartment.Photo.Add(new Photo() { Path = reader.GetString(0) });
                //        }
                //    }
                //}
            }
            return apartment;
        }

        public List<Apartment> GetTop()
        {
            List<Apartment> apartments = new List<Apartment>();
            Apartment apartment = new Apartment();
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
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            apartment = new Apartment()
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
                            apartment.Photo = new List<Photo>();
                            apartments.Add(apartment);
                        }
                    }
                    reader.Close();
                }
                for (int i = 0; i < 3; i++)
                {
                    apartments[i].Photo = GetPhotos(apartments[i].PathPhoto);
                }
                //for (int i = 0; i < 3; i++)
                //{
                //    using (SqlCommand cmd = con.CreateCommand())
                //    {

                //        cmd.Connection = con;
                //        //cmd.CommandType = System.Data.CommandType.Text;
                //        cmd.CommandType = System.Data.CommandType.Text;
                //        cmd.CommandText = $"SELECT [Photo] FROM [Photo] where ObjectId=@id ";
                //        cmd.Parameters.Add(new SqlParameter("@id", apartments[i].Id));
                //        SqlDataReader reader = cmd.ExecuteReader();
                //        if (reader.HasRows)
                //        {
                //            while (reader.Read())
                //            {
                //                apartments[i].Photo.Add(new Photo() { Path = reader.GetString(0) });
                //            }
                //        }
                //        reader.Close();
                //    }
                //}
            }

            return apartments;
        }
    }
}
