
using System;
using System.Collections;
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
        public void PoolCreated_CheckProperties()
        {
            var pool = new UserPoolModel();
            Assert.IsNotNull(pool.Users);
            Assert.IsEmpty(pool.Users);
            Assert.IsNotNull(pool.UsersInSources);
            Assert.IsEmpty(pool.UsersInSources);
        }

        [Test]
        public void PoolEmpty_Synchronize_PoolContainsDefaultUserAndUsersInSource()
        {
            var pool = new UserPoolModel();
            Assert.IsEmpty(pool.UsersInSources);
            //Assert.AreEqual(0, pool.UsersInSources.Count, "Pool is not empty after creation");

            // create a mock object implementing IRepository
            var repos = Substitute.For<IRepository>();
            
            // specify what property "Users" shall return on call 
            repos.Users.Returns(x => new UserInSourceBase[] { new StubUserInSource() });

            
            //TODO:
            // Perform synchronization from the stub
            //UserSynchronizer.Synchronize(pool, repos); // prefer this for SRP
            //pool.Synchronize();

            //UserPoolModel.Load("TestFiles/Test2.xml");
            //Assert.AreEqual(1,pool.Counter);
            
                            
            // UserSynchronizer.Synchronize(pool, repos);

            Assert.IsNotEmpty(pool.UsersInSources);
        }
	}
}