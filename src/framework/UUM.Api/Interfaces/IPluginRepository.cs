using System.Collections.ObjectModel;

namespace UUM.Api.Interfaces
{
    public interface IPluginRepository
    {
        void Initialize();
        ObservableCollection<IPlugin> Plugins { get; }
    }
}