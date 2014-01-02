
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

			// create a stub object implementing IRepository
			var repos = Substitute.For<IRepository>();
			
			// specify what property "Users" shall return on call
			repos.Users.Returns(x => new UserInSourceBase[] { new StubUserInSource() });

			
			//TODO:
			// Perform synchronization from the stub
			// prefer this for SRP

			Assert.IsNotEmpty(pool.UsersInSources);
		}
		
		public UserModel UserA
		{
			get;
			private set;
		}
		
		public UserModel UserB
		{
			get;
			private set;
		}
		
		[Test]
		public void Users_Synchronize_inPool_Adding_from_pool()
		{
			//Testing the Add function in pool
			UserPoolModel pool1 = new UserPoolModel();
			Assert.AreEqual(0,pool1.Counter);
			pool1.Add(UserA);
			Assert.AreEqual(1,pool1.Counter);
			
		}
		[Test]
		public void Users_Synchronize_inPool_Removing_from_pool()
		{
			//Testing the remove function in pool
			UserPoolModel pool2 = new UserPoolModel();
			Assert.AreEqual(0,pool2.Counter);
			pool2.Add(UserB);
			Assert.AreEqual(1,pool2.Counter);
			pool2.Remove(UserB);
			Assert.AreEqual(0,pool2.Counter);
		}
		
		
	}
}