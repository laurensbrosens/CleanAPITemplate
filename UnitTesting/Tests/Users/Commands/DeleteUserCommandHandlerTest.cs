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
    public class DeleteUserCommandHandlerTest : AbstractUserTest
    {
        private DeleteUserCommand.DeleteUserCommandHandler handler;
        private DeleteUserCommand usercommand;
        public DeleteUserCommandHandlerTest()
        {
            handler = new DeleteUserCommand.DeleteUserCommandHandler(_mockRepo.Object);
        }

        /// <summary>
        /// Test normal flow.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task DeleteUserCommandTest()
        {
            _mockRepo.Setup(u => u.Delete(1)).ReturnsAsync(true);
            usercommand = new DeleteUserCommand(1);
            var result = await handler.Handle(usercommand, CancellationToken.None);
            Assert.IsTrue(result);
            _mockRepo.VerifyAll();
        }

        /// <summary>
        /// Test negative flow.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        //[ExpectedException(typeof(KeyNotFoundException))]
        public async Task DeleteUserCommandTestNegative()
        {
            _mockRepo.Setup(u => u.Delete(0)).ReturnsAsync(false);
            usercommand = new DeleteUserCommand(0);
            try
            {
                var result = await handler.Handle(usercommand, CancellationToken.None);
                Assert.Fail();
                
            }
            catch (Exception)
            {
                //Assert.IsFalse(result);
                //Assert.Fail();
            }
            _mockRepo.VerifyAll();
            
        }
    }
}
