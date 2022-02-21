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

namespace UnitTesting.Tests.Users.Commands
{
    [TestClass]
    public class AddUserCommandHandlerTest : AbstractUserTest
    {
        private AddUserCommand.AddUserCommandHandler handler;
        private AddUserCommand usercommand;
        public AddUserCommandHandlerTest()
        {
            handler = new AddUserCommand.AddUserCommandHandler(_mockRepo.Object);
        }

        /// <summary>
        /// Test normal flow.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task AddUserCommandTest()
        {
            _mockRepo.Setup(u => u.Add(testUser)).ReturnsAsync(testUser);
            usercommand = new AddUserCommand(testUser);
            var result = await handler.Handle(usercommand, CancellationToken.None);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, testUser.Id);
            _mockRepo.VerifyAll();
        }

        /// <summary>
        /// Test negative flow.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task AddUserCommandTestNegative()
        {
            User user = null;
            _mockRepo.Setup(u => u.Add(user)).ReturnsAsync(user);
            usercommand = new AddUserCommand(user);
            var result = await handler.Handle(usercommand, CancellationToken.None);
            _mockRepo.VerifyAll();
            Assert.IsNull(result);
        }
    }
}
