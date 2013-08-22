using System;
using System.ComponentModel.Composition;
using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Plugin.Wmi.Models;

namespace UUM.Plugin.Wmi
{
    [Export(typeof (IPlugin))]
    public class WmiPlugin : IPlugin
    {
        internal static readonly Guid PluginId = new Guid("{6DB2B502-E399-4938-A309-CE998D562C5E}");
        
		public Guid Id
        {
            get { return PluginId; }
        }

        public string Name
        {
            get { return "WMI"; }
        }

        public string Description
        {
            get { return "Plugin for local or remote computer users and groups over WMI"; }
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