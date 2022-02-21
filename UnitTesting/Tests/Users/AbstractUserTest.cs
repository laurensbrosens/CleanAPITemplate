using Core.Interfaces;
using Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Users.Commands;
using System.Threading;

namespace UnitTesting.Tests.Users
{
    public abstract class AbstractUserTest
    {
        protected User testUser;
        protected Mock<IUserRepository> _mockRepo;

        public AbstractUserTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            testUser = new User()
            {
                Fingerprint = null,
                Name = "test",
                Visits1 = 1,
                Visits2 = 2,
                Id = 0
            };
        }
    }
}
