using System.ComponentModel.Composition;
using UUM.Api;

namespace UUM.Plugin.Doors
{
    [Export(typeof(IPlugin))]
    public class DoorsPlugin : IPlugin
    {
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
            throw new System.NotImplementedException();
        }
    }
}
