using System;
using System.ComponentModel.Composition;
using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Plugin.Sbm.Models;

namespace UUM.Plugin.Sbm
{
    [Export(typeof (IPlugin))]
    public class SbmPlugin : IPlugin
    {
        internal static readonly Guid PluginId = new Guid("{BBFAD1BD-E4AE-4DBB-ABA7-BA35F94F62AD}");
        
		public Guid Id
        {
            get { return PluginId; }
        }

        public string Name
        {
            get { return "SBM"; }
        }

        public string Description
        {
            get { return "Plugin for Serena Business Manager users and groups"; }
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