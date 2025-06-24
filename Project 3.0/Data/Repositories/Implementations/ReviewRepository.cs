
using System.Data.SqlClient;
using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Review> GetAll()
        {
            List<Review> reviews = new List<Review>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_review_all";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Review review = new Review()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Text = reader.GetString(3),
                                Mark = reader.GetInt32(4),
                                JobTitle = reader.GetString(5),
                                Date = reader.GetDateTime(6)
                            };
                            reviews.Add(review);
                        }
                    }
                }
            }
            return reviews;
        }

        public Review GetReviewAgentById(int id)
        {
            Review review = new Review();


            return review;
        }
    }
}
