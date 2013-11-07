using System.Collections.ObjectModel;

namespace UUM.Api.Interfaces
{
	/// <summary>
	/// Initiates all plugins.
	/// </summary>
    public interface IPluginRepository
    {
        void Initialize();
        ObservableCollection<IPlugin> Plugins { get; }
    }
}