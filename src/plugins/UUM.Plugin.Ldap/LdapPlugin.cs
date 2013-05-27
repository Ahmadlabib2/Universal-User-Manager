using System.ComponentModel.Composition;
using UUM.Api;

namespace UUM.Plugin.Ldap
{
    [Export(typeof(IPlugin))]
    public class LdapPlugin : IPlugin
    {
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
            throw new System.NotImplementedException();
        }
    }
}
