using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication.Repositories.Interfaces;

namespace WebApplication.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        
        public User LoginDetailsMatched(string email, string password)
        {
            return Context.Set<User>().FirstOrDefault(usr => usr.Email == email);
        }
    }
}