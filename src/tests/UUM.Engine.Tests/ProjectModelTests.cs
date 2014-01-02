/*
 * Created by SharpDevelop.
 * User: Ahmed-Labib.Wadi
 * Date: 02.01.2014
 * Time: 12:04
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
	public class ProjectModelTests
	{
		[Test]
		public void PrjectModel_Default_IsNotEmpty()
		{
		//Testing project model default value is never empty
		ProjectModel project1 = new ProjectModel();
		Assert.IsNotEmpty(project1.Parameters,"It is empty");
		}
	}
}
