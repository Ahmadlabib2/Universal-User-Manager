using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;

using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Plugin.Sbm.Models;

namespace UUM.Plugin.Sbm
{
    [Export(typeof (IPlugin))]
    [Guid("BBFAD1BD-E4AE-4DBB-ABA7-BA35F94F62AD")]
    public class SbmPlugin : PluginBase<Parameters, UserInSource>
    {
		#region Constructors
		public SbmPlugin()
		{
			Name = "SBM";
			Description = "Plugin for Serena Business Manager users and groups";
		}
		#endregion
    	
		protected override IRepository GetRepositoryInternal(Parameters parameters)
		{
			throw new NotImplementedException();
		}
    }
}