using ConvertMetric.Web.Models;
using System.Threading.Tasks;

namespace ConvertMetric.Web.HttpRepository.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
        Task<User> LoginAsync(string url, User objToCreate);
        Task<bool> RegisterAsync(string url, User objToCreate);

    }
}
