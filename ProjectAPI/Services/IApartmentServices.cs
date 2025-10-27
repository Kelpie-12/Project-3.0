namespace ProjectAPI.Services
{
    public interface IApartmentServices
    {
        Task<string> GetAll(bool @new);
        Task<string> GetTop();
    }
}
