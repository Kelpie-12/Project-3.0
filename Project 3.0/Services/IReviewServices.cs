using Project_3._0.Model.Domain;

namespace Project_3._0.Services
{
    public interface IReviewServices
    {
        Review GetReviewsByAgentId(int id);
        List<Review> GetAll();
    }
}
