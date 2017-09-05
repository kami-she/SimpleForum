using Data;
using InMemoryDbSet;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UnityContainer container = new UnityContainer();
        private IUserService userService;
        private Mock<IForumContext> db;
        private InMemoryDbSet<User> users;

        [TestInitialize]
        public void TestInitialize()
        {
            db = new Mock<IForumContext>();
            users = new InMemoryDbSet<User>();
            db.Setup(x => x.Users).Returns(users);
            db.Setup(x => x.Set<User>()).Returns(users);
            container
                   .RegisterType<IUserService, UserService>()
                   .RegisterInstance(db.Object);
            userService = container.Resolve<IUserService>();
        }

        [TestMethod]
        public void AddUser()
        {
            Assert.AreEqual(0, userService.GetAll().Count());
            User user = new User() { UserName = "Nina", Password = "123", Email = "Kkk" };
            userService.Create(user);
            Assert.AreEqual(1, userService.GetAll().Count());
        }

        [TestMethod]
        public void DeleteUser()
        {
            User user = new User() { Id = 1, UserName = "Nina", Password = "123", Email = "Kkk" };
            userService.Create(user);
            Assert.AreEqual(1, userService.GetAll().Count());
            userService.Delete(user);
            Assert.AreEqual(0, userService.GetAll().Count());
        }

        [TestMethod]
        public void UpdateUser()
        {
            User user = new User() { Id = 1, UserName = "Nina", Password = "123", Email = "Kkk" };
            userService.Create(user);
            user.UserName = "Katya";
            user.Password = "222";
            userService.Update(user);
            Assert.AreEqual("Katya", userService.GetById(1).UserName);
            Assert.AreEqual("222", userService.GetById(1).Password);
        }
    }
}
