using System.ComponentModel.Composition;
using UUM.Api;

namespace UUM.Plugin.Subversion
{
    [Export(typeof(IPlugin))]
    public class SubversionPlugin : IPlugin
    {
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
