using System;
using System.ComponentModel.Composition;
using UUM.Api;
using UUM.Api.Interfaces;

namespace UUM.Plugin.Doors
{
    [Export(typeof (IPlugin))]
    public class DoorsPlugin : IPlugin
    {
        internal static readonly Guid PluginId = new Guid("{E25D7256-EE26-45E5-A781-C7FDB9B5ABA3}");

        public Guid Id
        {
            get { return PluginId; }
        }

        public string Name
        {
            get { return "Doors"; }
        }

        public string Description
        {
            get { return "Plugin for the DOORS requirements management system"; }
        }

        public IRepository GetRepository(IParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}