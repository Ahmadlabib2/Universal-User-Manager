using System.Collections.ObjectModel;
using UUM.Api.Interfaces;

namespace UUM.Engine.Interfaces
{
    public interface IPluginRepository
    {
        void Initialize();
        ObservableCollection<IPlugin> Plugins { get; }
    }
}
