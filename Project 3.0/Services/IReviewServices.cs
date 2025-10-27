using Project_3._0.Model.Domain;

namespace Project_3._0.Services
{
    public interface IReviewServices
    {
        Task<Review> GetReviewsByAgentId(int id);
        Task<List<Review>> GetAll();
    }
}
