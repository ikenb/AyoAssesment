using ConvertMetricUnits.Data.Models;

namespace ConvertMetricUnits.Core.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        User Authenticate(string username, string password);
        User Register(string username, string password, string role);
    }
}
