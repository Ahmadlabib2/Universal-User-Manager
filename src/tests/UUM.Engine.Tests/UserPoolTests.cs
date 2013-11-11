
using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Engine.Models;

namespace UUM.Engine.Tests
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	[TestFixture]
	public class UserPoolTests
	{
        [Test]
        public void PoolEmpty_Synchronize_PoolContainsDefaultUserAndUsersInSource()
        {
            var pool = new UserPoolModel();
            Assert.IsEmpty(pool.UsersInSources);

            var repos = Substitute.For<IRepository>();
            repos.Users.Returns(x => new UserInSourceBase[] { new StubUserInSource() });

            //TODO:
            // Perform synchronization from the stub
            // UserSynchronizer.Synchronize(pool, repos);

            Assert.IsNotEmpty(pool.UsersInSources);
        }
	}
}