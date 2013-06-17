using System;
using System.ComponentModel.Composition;
using UUM.Api.Interfaces;
using UUM.Plugin.Ldap.Models;

namespace UUM.Plugin.Ldap
{
    [Export(typeof (IPlugin))]
    public class LdapPlugin : IPlugin
    {
        internal static readonly Guid PluginId = new Guid("{11CBEB4D-56B2-4A26-9706-D13C946ED316}");

        public Guid Id
        {
            get { return PluginId; }
        }

        public string Name
        {
            get { return "Ldap"; }
        }

        public string Description
        {
            get { return "Plugin for the Ldap system"; }
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