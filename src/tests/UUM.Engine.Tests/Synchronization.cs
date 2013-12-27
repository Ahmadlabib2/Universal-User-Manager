/*
 * Created by SharpDevelop.
 * User: Ahmed-Labib.Wadi
 * Date: 24.12.2013
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Engine.Models;

namespace UUM.Engine.Tests
{
	[TestFixture]
	public class Synchronization
	{
		[Test]
		public void Synchronizing()
		{
			var pool = new UserPoolModel();
			var repos = Substitute.For<IRepository>();
			var synchronizer = new UserSynchronizer();
			
			repos.Users.Returns(x => new UserInSourceBase[] { new StubUserInSource() });
			
			synchronizer.Synchronize(pool, repos);
			Assert.AreEqual(2,pool.Counter); 
		}
	}
}
