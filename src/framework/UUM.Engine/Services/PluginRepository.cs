using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using UUM.Api.Interfaces;

namespace UUM.Engine.Services
{
	/// <summary>
	/// Loading of all different plugins and adding a log of it in a container.
	/// </summary>
    public class PluginRepository : IPluginRepository
    {
        public void Initialize()
        {
            if (Plugins == null)
            {
                // MEF loading of available plug-ins
                var catalog = new DirectoryCatalog(".", "UUM.Plugin.*.dll");
                var container = new CompositionContainer(catalog);

                container.SatisfyImportsOnce(this);
            }
        }

        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IPlugin> Plugins { get; set; }

    }
}