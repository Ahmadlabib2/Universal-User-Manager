using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Plugin.Ldap.Models;

namespace UUM.Plugin.Ldap
{
    [Export(typeof (IPlugin))]
    [Guid("11CBEB4D-56B2-4A26-9706-D13C946ED316")]
    public class LdapPlugin : PluginBase<Parameters>
    {
		#region Constructors
		public LdapPlugin()
		{
			
			Name = "Ldap";
			Description = "Plugin for the Ldap system";
		}
		#endregion
    	
		protected override IRepository GetRepositoryInternal(Parameters parameters)
		{
			throw new NotImplementedException();
		}
    }
}