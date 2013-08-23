using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Plugin.Doors.Models;

namespace UUM.Plugin.Doors
{
	[Export(typeof (IPlugin))]
	[Guid("E25D7256-EE26-45E5-A781-C7FDB9B5ABA3")]
	public class DoorsPlugin : PluginBase<Parameters>
	{
		#region Constructors
		public DoorsPlugin()
		{
			Name = "Doors";
			Description = "Plugin for the DOORS requirements management system";
		}
		#endregion
		
		protected override IRepository GetRepositoryInternal(Parameters parameters)
		{
			throw new NotImplementedException();
		}
	}
}