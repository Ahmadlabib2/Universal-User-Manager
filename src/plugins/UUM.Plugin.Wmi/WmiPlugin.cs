using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;

using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Plugin.Wmi.Models;

namespace UUM.Plugin.Wmi
{
    [Export(typeof (IPlugin))]
    [Guid("6DB2B502-E399-4938-A309-CE998D562C5E")]
    public class WmiPlugin : PluginBase<Parameters, UserInSource>
    {
		#region Constructors
		public WmiPlugin()
		{
			Name = "WMI";
			Description = "Plugin for local or remote computer users and groups over WMI";
		}
		#endregion

		protected override IRepository GetRepositoryInternal(Parameters parameters)
		{
			throw new NotImplementedException();
		}
    }
}