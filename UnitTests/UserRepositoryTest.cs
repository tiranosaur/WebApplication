using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebApplication.Models;
using WebApplication.Repositories;
using Xunit;

namespace UnitTests
{
    public class UserRepositoryTest
    {
        [Fact]
        public void GetAll()
        {
            // Arrange
            var user1 = new User() { Id = 1, Name = "UserName", Age = 33, Email = "mail@gmail.com" };
            var user2 = new User() { Id = 2, Name = "UserName2", Age = 13, Email = "mailsdfsdfsdf@gmail.com" };
            var testList = new List<User>() { user1, user2 };

            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.As<IQueryable<User>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.GetEnumerator())
                .Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<User>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.Equal(testList, result.ToList());
        }

        [Fact]
        public void GetAllMemory()
        {
            // Arrange
            using var ctx = new ApplicationContext();
            var userRepository = new UserRepository(ctx);

            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "UserName", Age = 33, Email = "mail@gmail.com" });
            users.Add(new User() { Id = 2, Name = "UserName2", Age = 13, Email = "mailsdfsdfsdf@gmail.com" });

            userRepository.AddRange(users);
            userRepository.SaveChanges();

            // Act

            List<User> result = ctx.Users.ToList();

            // Assert
            Assert.Equal(users, result);
        }
    }
}