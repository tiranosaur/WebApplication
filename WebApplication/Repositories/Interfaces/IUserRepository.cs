using WebApplication.Models;

namespace  WebApplication.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User LoginDetailsMatched(string email, string password);
    }
}
