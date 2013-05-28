using System;
using System.ComponentModel.Composition;
using UUM.Api;
using UUM.Api.Interfaces;

namespace UUM.Plugin.Subversion
{
    [Export(typeof(IPlugin))]
    public class SubversionPlugin : IPlugin
    {
        internal static readonly Guid PluginId = new Guid("{5D4E8772-0C14-4B2B-8BD5-347DAE494C4E}");

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

        public IRepository GetRepository(IParameters parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
