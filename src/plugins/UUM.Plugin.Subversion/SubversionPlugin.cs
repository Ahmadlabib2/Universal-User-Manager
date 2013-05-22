using System.ComponentModel.Composition;
using UUM.Api;

namespace UUM.Plugin.Subversion
{
    [Export(typeof(IPlugin))]
    public class SubversionPlugin : IPlugin
    {
    }
}
