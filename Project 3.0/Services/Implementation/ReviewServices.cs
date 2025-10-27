using System.ComponentModel;
using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class ReviewServices : IReviewServices
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewServices(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }



        async Task<List<Review>> IReviewServices.GetAll()
        {
            return await _reviewRepository.GetAll();
        }

        Task<Review> IReviewServices.GetReviewsByAgentId(int id)
        {
            return _reviewRepository.GetReviewAgentById(id);
        }
    }
}
