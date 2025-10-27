using ProjectAPI.Model;

namespace ProjectAPI.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync();
        Task<Review> GetReviewAgentByIdAsync(int id);
    }
}
