using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        Review GetReviewAgentById(int id);
    }
}
