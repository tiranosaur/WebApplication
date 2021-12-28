using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private UserRepository _userRepository;

        public UserController(ApplicationContext ctx)
        {
            _userRepository = new UserRepository(ctx);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<User>> Index()
        {
            return await _userRepository.GetDbSet().AsNoTracking().ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userRepository.GetDbSet().AsNoTracking().Where(x => x.Id == id).FirstAsync();
        }

        [HttpPost]
        [Route("")]
        public User Create(User user)
        {
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return user;
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<User> Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return user;
        }
        
        [HttpDelete]
        [Route("{id}")]
        public void Remove(User user)
        {
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }
    }
}