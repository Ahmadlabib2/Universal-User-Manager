using System.Collections.ObjectModel;

using Catel.Data;
using Catel.MVVM;

using UUM.Api.Interfaces;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	/// Views the different loaded plugins to be able to select.
	/// </summary>
	public class ChoosePluginViewModel : ViewModelBase
	{
		public ChoosePluginViewModel(IPluginRepository pluginRepository)
		{
			Plugins = pluginRepository.Plugins;
		}

		#region Property: Plugins

        /// <summary>
        /// Available plugins
        /// </summary>
        public ObservableCollection<IPlugin> Plugins
        { get; private set; }

		#endregion

        #region Property: SelectedPlugin

        public IPlugin SelectedPlugin
        { get; set; }

        #endregion
    }
}
