using System.Collections.ObjectModel;

using Catel.Data;
using Catel.MVVM;

using UUM.Api.Interfaces;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	/// Description of ChoosePluginViewModel.
	/// </summary>
	public class ChoosePluginViewModel : ViewModelBase
	{
		public ChoosePluginViewModel(IPluginRepository pluginRepository)
		{
			Plugins = pluginRepository.Plugins;
		}

		#region Model
		/// <summary>
		/// Loads the Plugins
		/// </summary>
		/// 
		public static readonly PropertyData PluginsProperty =
			RegisterProperty("Plugins", typeof (ObservableCollection<IPlugin>), null);

		public ObservableCollection<IPlugin> Plugins
		{
			get { return GetValue<ObservableCollection<IPlugin>>(PluginsProperty); }
			set { SetValue(PluginsProperty, value); }
		}

		#region Property: SelectedPlugin
		
		public static readonly PropertyData SelectedPluginProperty =
			RegisterProperty("SelectedPlugin", typeof (IPlugin), null);

		public IPlugin SelectedPlugin
		{
			get { return GetValue<IPlugin>(SelectedPluginProperty); }
			set { SetValue(SelectedPluginProperty, value); }
		}

		#endregion
		#endregion
		
	}
}
