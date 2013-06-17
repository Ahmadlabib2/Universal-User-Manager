using System;
using System.ComponentModel.Composition;
using UUM.Api.Interfaces;
using UUM.Plugin.Doors.Models;

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
            if (!(parameters is Parameters))
                throw new InvalidOperationException("Parameters not belonging to this plugin");

            throw new NotImplementedException();
        }

        public IParameters GetParameters()
        {
            return new Parameters();
        }
    }
}