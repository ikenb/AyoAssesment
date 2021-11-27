using ConvertMetric.Web.Models;

namespace ConvertMetric.Web.HttpRepository.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
        Task<User> LoginAsync(string url, User objToCreate);
        Task<bool> RegisterAsync(string url, User objToCreate);

    }
}
