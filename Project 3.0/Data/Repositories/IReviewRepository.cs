using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAll();
        Task<Review> GetReviewAgentById(int id);
    }
}
