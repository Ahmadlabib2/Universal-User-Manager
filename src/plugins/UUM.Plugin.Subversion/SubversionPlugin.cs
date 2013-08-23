using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;

using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Plugin.Subversion.Models;

namespace UUM.Plugin.Subversion
{
    [Export(typeof (IPlugin))]
    [Guid("5D4E8772-0C14-4B2B-8BD5-347DAE494C4E")]
    public class SubversionPlugin : PluginBase<Parameters, UserInSource>
    {
		#region Constructors
		public SubversionPlugin()
		{
			Name = "Subversion";
			Description = "Plugin for the Subversion file based rights system";
		}
		#endregion
    	
		protected override IRepository GetRepositoryInternal(Parameters parameters)
		{
			throw new NotImplementedException();
		}
    }
}