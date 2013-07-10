using System;
using System.ComponentModel.Composition;
using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Plugin.Subversion.Models;

namespace UUM.Plugin.Subversion
{
    [Export(typeof (IPlugin))]
    public class SubversionPlugin : IPlugin
    {
        internal static readonly Guid PluginId = new Guid("{5D4E8772-0C14-4B2B-8BD5-347DAE494C4E}");
		
        internal static readonly string NameofPlugin = "sub";
        
		public Guid Id
        {
            get { return PluginId; }
        }

        public string Name
        {
            get { return "Subversion"; }
        }

        public string Description
        {
            get { return "Plugin for the Subversion file based rights system"; }
        }

        public IRepository GetRepository(ParametersBase parameters)
        {
            if (!(parameters is Parameters))
                throw new InvalidOperationException("Parameters not belonging to this plugin");

            throw new NotImplementedException();
        }

        public ParametersBase GetParameters()
        {
            return new Parameters();
        }
    }
}